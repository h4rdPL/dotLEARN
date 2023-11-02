﻿using dotLearn.Application.Common.Interfaces.Authentication;
using dotLearn.Application.Common.Interfaces.ClassPersistence;
using dotLearn.Application.Common.Interfaces.Persisence;
using dotLearn.Domain.DTO;
using dotLearn.Domain.Entities;
using dotLearn.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotLearn.Infrastructure.ClassEntitities
{
    public class ClassRepository : IClassRepository
    {

        private readonly DotLearnDbContext _context;
        public ClassRepository(DotLearnDbContext context)
        {
            _context = context;
        }
        public async Task<ClassPdfFile> AddPDFFIle(int professorId, IFormFile fileUploadDTO, int ClassId)
        {
            try
            {
                var classId = await _context.Classes
                    .Where(c => c.ProfessorId == professorId && c.Id == ClassId)
                    .Select(c => c.Id)
                    .FirstOrDefaultAsync();

                if (classId == 0)
                {
                    throw new Exception("Error while returning class");
                }

                byte[] fileBytes;
                using (var stream = new MemoryStream())
                {
                    await fileUploadDTO.CopyToAsync(stream);
                    fileBytes = stream.ToArray();
                }
                var classPdfFile = new ClassPdfFile
                {
                    ClassId = classId,
                    PdfFile = new PdfFile
                    {
                        Name = fileUploadDTO.FileName,
                        FileContent = fileBytes
                    }
                };

                _context.ClassPdfFiles.Add(classPdfFile);

                await _context.SaveChangesAsync();

                return classPdfFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClassEntities> Create(ClassEntities classEntity)
        {
            try
            {
                _context.Classes.Add(classEntity);
                await _context.SaveChangesAsync();
                return classEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("Class creation failed.", ex);
            }
        }

        public List<StudentAndProfessorClassesDTO> GetAll(User user)
        {
            var classesWithProfessorsAndPDFs = _context.Classes
                .Where(ce => _context.ClassEntitiesStudents
                    .Any(ces => ces.ClassEntitiesId == ce.Id && ces.StudentId == user.Id) || ce.ProfessorId == user.Id)
                .Select(ce => new StudentAndProfessorClassesDTO
                {
                    Id = ce.Id,
                    ClassName = ce.ClassName,
                    ClassCode = ce.ClassCode,
                    FirstName = ce.Professor.FirstName,
                    LastName = ce.Professor.LastName,
                    PdfFiles = _context.ClassPdfFiles
                        .Where(cp => cp.ClassId == ce.Id)
                        .Select(cp => cp.PdfFile)
                        .ToList(),
                    StudentNumbers = _context.ClassEntitiesStudents
                        .Where(ces => ces.ClassEntitiesId == ce.Id)
                        .Select(ces => ces.StudentId)
                        .Distinct()
                        .Count()
                })
                .ToList();

            return classesWithProfessorsAndPDFs;
        }



        public async Task<List<PdfFile>> GetClassPDFFiles(int userId)
        {
            try
            {
                var pdfFiles = await _context.ClassPdfFiles
                    .Where(cp => cp.Class.ProfessorId == userId)
                    .Select(cp => cp.PdfFile)
                    .ToListAsync();

                return pdfFiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetNumberOfStudents(int classId)
        {
            try
            {
                var numberOfStudents = await _context.ClassEntitiesStudents
                    .Where(s => s.ClassEntitiesId == classId)
                    .Select(s => s.StudentId)
                    .Distinct()
                    .CountAsync();
                return numberOfStudents;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public PdfFile GetPdfFileContent(int userId, string fileName)
        {
            var userClass = _context.ClassEntitiesStudents
                .Include(ce => ce.Student)
                .SingleOrDefault(ce => ce.Student.Id == userId);


            var pdfFile = _context.ClassPdfFiles
                .Include(cp => cp.PdfFile) 
                .FirstOrDefault(cp => cp.ClassId == userClass.ClassEntitiesId && cp.PdfFile.Name == fileName);

            if (pdfFile == null)
            {
                throw new FileNotFoundException("PDF file not found.");
            }

            var pdfFileResponse = new PdfFile
            {
                Name = pdfFile.PdfFile.Name,
                FileContent = pdfFile.PdfFile.FileContent
            };

            return pdfFileResponse;
        }
        
        public async Task<ClassEntitiesStudent> JoinToClassByCode(int userId, string classCode)
        {
            try
            {
                var classId = _context.Classes.FirstOrDefault(x => x.ClassCode == classCode);

                var existingRelation = _context.ClassEntitiesStudents
                .FirstOrDefault(r => r.StudentId == userId && r.ClassEntitiesId == classId.Id);
                if(existingRelation is not null)
                {
                    throw new Exception("Student już należy do danej klasy");
                }
                var classStudent = new ClassEntitiesStudent
                {
                    StudentId = userId,
                    ClassEntitiesId = classId.Id
                };

                _context.ClassEntitiesStudents.Add(classStudent);
                await _context.SaveChangesAsync();
                return classStudent;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Remove(ClassEntities classEntity)
        {
            throw new NotImplementedException();
        }
    }
}
