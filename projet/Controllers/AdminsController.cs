﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.EntityFrameworkCore;
using projet.Models;
using projet.Services;
using Microsoft.AspNetCore.Authorization;

namespace projet.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminsController : Controller
    {
        private readonly PrjContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private List<Enseignant> listEns = new List<Enseignant>();

        private RepositoryEnseignant  repo;
        public AdminsController(RepositoryEnseignant rep, IHostingEnvironment hostingEnvironment)
        {
            repo = rep;
            _hostingEnvironment = hostingEnvironment;
        }

        /*************************************************operation by Admin*******************************************************/

        //page import excel file
        public IActionResult ImportExcelAddEns()
        {
            return View();
        }

        // insert database teacher

        [HttpPost]
        public ActionResult OnPostImport()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "FichierAddDBEnseignants";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
           
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {

               
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {

                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<h1>hello</h1><table class='table'><tr>");

                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");
                  
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                       
                        int c = 0;
                        Enseignant ens = new Enseignant();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)


                            if (c == 0)
                            {
                                    ens.nom = row.GetCell(j).ToString();
                                c++;
                            }
                            else if (c == 1)
                            {
                                ens.prenom = row.GetCell(j).ToString();
                                c++;
                            }
                            else if(c ==2)
                            {
                                ens.username = row.GetCell(j).ToString();
                                    c++;

                            }
                          else if (c == 3)
                            {
                                ens.mdp = row.GetCell(j).ToString();
                                c++;
                            }
                            else if (c == 4)
                            {
                                ens.email= row.GetCell(j).ToString();
                                c++;
                            }
                            else if (c == 5)
                            {
                                    ens.telephone = row.GetCell(j).ToString();
                                    c++;
                            }
                            else if (c == 6)
                            {
                                
                                    ens.photo = row.GetCell(j).ToString();
                                
                                    listEns.Add(ens);
                                    repo.SaveEns(ens);
                                  
                                    c = 0;
                                }


                               
                        }
                      

                        
                      
                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");

                }
            }
        
            ViewBag.msg = "The list of teachers is imported into the database";
            return View("ListExcelAddEns", listEns);
        }

        public IActionResult ListExcelAddEns()
        {
            ViewBag.msg = "The list of teachers is imported into the database";
            return View(listEns);
        }

        public IActionResult CreateEnsFormulaire()
        {
            ViewBag.msg = "";
            return View();
        }
        // create Teacher
        public IActionResult CreateEns(string nom ,string prenom,string username,string mdp,string email,string telephone)
        {

            if( nom!=null && prenom!=null && username!=null && mdp!=null && email!=null && telephone != null) {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadImages";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                

                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                  
                   

                }

            }

                Enseignant ens = new Enseignant();
                ens.nom = nom;
                ens.photo = file.FileName;
                ens.prenom = prenom;
                ens.username = username;
                ens.mdp = mdp;
                ens.email = email;
                ens.telephone = telephone;
                repo.SaveEns(ens);
                ViewBag.msg = "teacher is inserted";
            }
            else
            {

                ViewBag.msg = "Error fields to check inserted fields";
            }
            return View("CreateEnsFormulaire");
        }

        
        // modify & delete page 

           public IActionResult TudoEns()
           {
            return View(repo.FindAllEns());
           }
        // delete teacher 
        public IActionResult DeleteEns(int Id)
        {
            repo.DeleteEns(Id);
            return View("TudoEns", repo.FindAllEns());
        }
        // Edit Teacher
        public IActionResult EditEns(int Id)
        {
            var ens = repo.GetEnsbyID(Id);
            return View(ens);
        }


        
        [HttpPost]
        public async Task<IActionResult> EditEnsAction(int id, [Bind("Id,nom,prenom,username,mdp,email,telephone")] Enseignant enseignant)
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadImages";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {


                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;



                }

            }
            enseignant.photo = file.FileName;
            repo.UpdateEns(enseignant);
            return View("TudoEns", repo.FindAllEns());
        }

        /**************************************************Infos Admin***************************************************************/
        // Page d'acceuil de l admin
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nom,prenom,username,mdp,email,photo")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nom,prenom,username,mdp,email,photo")] Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Logout(int id)
        {
            Response.Cookies.Delete("jwttoken");
            return RedirectToAction("Index", "Home");

        }
    }
}
