using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using snack_spot.Models;

namespace snack_spot.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminManagerImagesController : Controller
{
    private readonly ConfigurationsImages _configurationsImages;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminManagerImagesController(IOptions<ConfigurationsImages> configurationsImages, IWebHostEnvironment webHostEnvironment)
    {
        _configurationsImages = configurationsImages.Value;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> UploadFiles(List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
        {
            ViewData["Erro"] = "Erro: Nenhum arquivo foi selecionado!";
            return View(ViewData);
        }

        if (files.Count > 20)
        {
            ViewData["Erro"] = "Erro: Não aceitamos mais que 10 arquivos por vez";
            return View(ViewData);
        }

        long size = files.Sum(f => f.Length);

        List<string> fileNames = new List<string>();

        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, _configurationsImages.NameFoldersImagesProducts);

        foreach (IFormFile formFile in files)
        {
            if (formFile.FileName.EndsWith(".jpg") || formFile.FileName.EndsWith(".png") || formFile.FileName.EndsWith(".bmp"))
            {
                string fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                fileNames.Add(formFile.FileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
        }

        ViewData["Result"] = $"{files.Count} arquivos foram enviados para o servidor, " +
                                $"com tamanho total de: {size} bytes";

        ViewBag.Files = fileNames;

        return View(ViewData);
    }

    public IActionResult GetImages()
    {
        FileManagerModel model = new FileManagerModel();

        string productsImagesPath = Path.Combine(_webHostEnvironment.WebRootPath, _configurationsImages.NameFoldersImagesProducts);

        DirectoryInfo directory = new DirectoryInfo(productsImagesPath);

        FileInfo[] files = directory.GetFiles();

        model.PathImagesProducts = _configurationsImages.NameFoldersImagesProducts;

        if (files.Length == 0)
        {
            ViewData["Erro"] = "Nenhum arquivo encontrado!";
        }

        model.Files = files;

        return View(model);
    }

    public IActionResult DeleteFile(string fname)
    {
        string imageDelete = Path.Combine(_webHostEnvironment.WebRootPath, _configurationsImages.NameFoldersImagesProducts + "\\", fname);

        if (System.IO.File.Exists(imageDelete))
        {
            System.IO.File.Delete(imageDelete);

            ViewData["Delete"] = $"Arquivo {fname} deletado com sucesso!";
        }

        return View("Index");
    }

}