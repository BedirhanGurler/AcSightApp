using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace AcSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsbController : ControllerBase
    {
        [HttpGet("detection")]
        public IActionResult Get()
        {
            // Tüm bağlı USB aygıtlarını al
            var usbDrives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable);

            // İlk USB aygıtını al
            var usbDrive = usbDrives.FirstOrDefault();

            // USB aygıtı bağlıysa
            if (usbDrive != null)
            {
                // Tüm dosyaları al
                var files = Directory.GetFiles(usbDrive.RootDirectory.FullName, "*.*", SearchOption.AllDirectories);

                // Dosyaları JSON olarak döndür
                return Ok(files);
            }

            // USB aygıtı bağlı değilse
            return NotFound();
        }
    }
}
