using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet.Models;

using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System;
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

namespace projet.Controllers
{
    public class Modules1Controller : Controller
    {
        private readonly PrjContext _context;
        private List<Module> listexcelmodu = new List<Module>();
        private readonly IHostingEnvironment _hostingEnvironment;

        public Modules1Controller(PrjContext context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: Modules1
        public async Task<IActionResult> Index()
        {
            var prjContext = _context.Modules.Include(a => a.Enseignant).Include(a => a.niveau);
            ViewBag.nomf = _context.Filieres.ToList();
            List<Enseignant> listens = new List<Enseignant>();
            listens = (from Enseignant in _context.Enseignants select Enseignant).ToList();
            ViewBag.listofens = listens;

            return View();
        }

        private IList<niveau> Getsubcategories(int id)
        {
            return _context.Niveaus.Where(m => m.id_fil == id).ToList();
        }
        public JsonResult getnivbyid(int id)
        {
            var subcategoriesList = Getsubcategories(id);
            var subcategoriesData = subcategoriesList.Select(m => new SelectListItem()
            {
                Text = m.nom_niv.ToString(),
                Value = m.id_niv.ToString(),
            });
            return Json(subcategoriesData);
        }




        // GET: Modules1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Modules
              .Include(a => a.Enseignant)
                .Include(a => a.niveau)
                .FirstOrDefaultAsync(m => m.id_mod == id);
            if (@module == null)
            {
                return NotFound();
            }
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View(@module);
        }

        // GET: Modules1/Create
        public IActionResult CreateModule()
        {
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "nom");
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv");
            ViewBag.filiere = _context.Filieres.ToList();
            return View();
        }

        // POST: Modules1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createmod([Bind("id_mod,nom_mod,Id,id_niv")] Module @module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                ViewBag.msg = "Module is inserted";
                return View("Create");
            }
            else
            {
                ViewBag.msg = "Error fields to check inserted fields";
            }
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "nom", @module.Id);
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv", @module.id_niv);

            return View("Create");
        }
        //    Create
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id_mod, string nom_mod, int id_niv, int Id)
        {
            Module mod = new Module();
            if (ModelState.IsValid)
            {


                //Enseignant ens = _context.Enseignants.FirstOrDefault(a => a.Id == Id);
                // niveau n = _context.Niveaus.FirstOrDefault(s => s.id_niv == id_niv);
                mod.id_mod = id_mod;
                mod.nom_mod = nom_mod;
                mod.Id = Id;
                mod.id_niv = id_niv;
                // _context.Niveaus.Add(n);
                //   _context.Enseignants.Add(ens);
                _context.Add(mod);
                await _context.SaveChangesAsync();
                ViewBag.msg = "Module is inserted";
            }
            else { ViewBag.msg = "Error fields to check inserted fields"; }
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "nom", mod.Id);
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv", mod.id_niv);
            ViewBag.filiere = _context.Filieres.ToList();
            return View("CreateModule");
        }

        // GET: Mo/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var @module = await _context.Modules.FindAsync(id);

            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "nom", @module.Id);
            ViewData["id_niv"] = new SelectList(_context.Niveaus.Where(a => a.id_niv == @module.id_niv), "id_niv", "nom_niv", @module.id_niv);
            return View(@module);
        }

        // POST: Mo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<ActionResult> Editmod(int id, [Bind("id_mod,nom_mod,Id,id_niv")] Module @module)
        {


            _context.Update(@module);
            await _context.SaveChangesAsync();

            return View("TudoEns", _context.Modules.Include(a => a.Enseignant).Include(a => a.niveau.Filiere).ToList());
        }

        // GET: Modules1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var fordelete = _context.Modules.Find(id);
            _context.Modules.Remove(fordelete);
            _context.SaveChanges();
            return View("TudoEns", _context.Modules.Include(a => a.Enseignant).Include(a => a.niveau.Filiere).ToList());
        }


        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.id_mod == id);
        }

        //page import excel file
        public IActionResult ImportExcelAddEns()
        {
            Module m = new Module();
            List<Enseignant> listens = new List<Enseignant>();
            listens = (from Enseignant in _context.Enseignants select Enseignant).ToList();
            ViewBag.listofens = listens;
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "nom", m.Id);
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv", m.id_niv);
            ViewBag.filiere = _context.Filieres.ToList();
            return View();
        }

        // insert database teacher

        [HttpPost]
        public async Task<IActionResult> OnPostImport(int id_mod, int id_niv)
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
                        Module ens = new Module();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {

                            if (row.GetCell(j) != null)


                                if (c == 0)
                                {
                                    ens.id_mod = id_mod;
                                    ens.nom_mod = row.GetCell(j).ToString();
                                    c++;
                                }
                                else if (c == 1)
                                {
                                    int e = _context.Enseignants.Where(a => a.nom == row.GetCell(j).ToString()).Select(a => a.Id).FirstOrDefault();
                                    ens.Id = e;

                                    ViewBag.nameens = row.GetCell(j).ToString();
                                    ens.id_niv = id_niv;

                                    listexcelmodu.Add(ens);
                                    _context.Add(ens);
                                    await _context.SaveChangesAsync();

                                    c = 0;
                                }



                        }




                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");

                }
            }

            ViewBag.msg = "The list of Modules is imported into the database";

            return View("ListExcelAddEns", listexcelmodu);
        }
        public IActionResult ListExcelAddEns()
        {
            ViewBag.msg = "The list of Modules is imported into the database";
            List<string> properties = listexcelmodu.Select(o => o.Enseignant.nom).ToList();
            ViewBag.nn = properties.ToList();
            return View(listexcelmodu);
        }



        public IActionResult TudoEns()
        {
            return View(_context.Modules.Include(a => a.Enseignant).Include(a => a.niveau.Filiere).ToList());
        }

    }
}
