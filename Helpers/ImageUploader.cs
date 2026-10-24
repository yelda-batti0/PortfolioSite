namespace PortfolioSite.Helpers
{
    public class ImageUploader
    {
        private const long MaxBytes = 5 * 1024 * 1024;
        private readonly IWebHostEnvironment _env;

        public ImageUploader(IWebHostEnvironment env)
        {
            _env = env;
        }

        // Başarılıysa (yol, null), hata varsa (null, mesaj) döner
        public async Task<(string? Path, string? Error)> SaveAsync(IFormFile file, string folder)
        {
            if (file.Length == 0) return (null, "Dosya boş.");
            if (file.Length > MaxBytes) return (null, "Görsel en fazla 5 MB olabilir.");

            var ext = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();
            if (ext is not (".jpg" or ".jpeg" or ".png" or ".webp"))
                return (null, "Sadece JPG, PNG veya WEBP yüklenebilir.");

            // İçerik imzası kontrolü
            var header = new byte[12];
            await using (var s = file.OpenReadStream())
            {
                var read = await s.ReadAsync(header, 0, header.Length);
                if (read < 12) return (null, "Geçersiz görsel.");
            }

            bool isJpeg = header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
            bool isPng = header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47;
            bool isWebp = header[0] == 0x52 && header[1] == 0x49 && header[2] == 0x46 && header[3] == 0x46
                          && header[8] == 0x57 && header[9] == 0x45 && header[10] == 0x42 && header[11] == 0x50;

            if (!(isJpeg || isPng || isWebp))
                return (null, "Dosya geçerli bir görsel değil.");

            var dir = System.IO.Path.Combine(_env.WebRootPath, "uploads", folder);
            Directory.CreateDirectory(dir);

            var name = Guid.NewGuid().ToString("N") + ext;
            var full = System.IO.Path.Combine(dir, name);

            await using (var fs = new FileStream(full, FileMode.Create))
                await file.CopyToAsync(fs);

            return ($"/uploads/{folder}/{name}", null);
        }

        public void Delete(string? webPath)
        {
            if (string.IsNullOrEmpty(webPath) || !webPath.StartsWith("/uploads/")) return;

            var full = System.IO.Path.GetFullPath(
                System.IO.Path.Combine(_env.WebRootPath, webPath.TrimStart('/')));
            var root = System.IO.Path.GetFullPath(System.IO.Path.Combine(_env.WebRootPath, "uploads"));

            // Sadece uploads klasörü içindeki dosyalar silinir
            if (full.StartsWith(root) && File.Exists(full))
                File.Delete(full);
        }

        public async Task<(string? Path, string? Error)> SavePdfAsync(IFormFile file, string folder)
        {
            if (file.Length == 0) return (null, "Dosya boş.");
            if (file.Length > MaxBytes) return (null, "PDF en fazla 5 MB olabilir.");

            var ext = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();
            if (ext != ".pdf") return (null, "Sadece PDF yüklenebilir.");

            var header = new byte[5];
            await using (var s = file.OpenReadStream())
            {
                var read = await s.ReadAsync(header, 0, header.Length);
                if (read < 5) return (null, "Geçersiz PDF.");
            }
            // %PDF-
            if (!(header[0] == 0x25 && header[1] == 0x50 && header[2] == 0x44 && header[3] == 0x46 && header[4] == 0x2D))
                return (null, "Dosya geçerli bir PDF değil.");

            var dir = System.IO.Path.Combine(_env.WebRootPath, "uploads", folder);
            Directory.CreateDirectory(dir);

            var name = Guid.NewGuid().ToString("N") + ".pdf";
            await using (var fs = new FileStream(System.IO.Path.Combine(dir, name), FileMode.Create))
                await file.CopyToAsync(fs);

            return ($"/uploads/{folder}/{name}", null);
        }
    }
}
