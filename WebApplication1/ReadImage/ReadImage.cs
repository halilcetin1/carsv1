namespace WebApplication1.ReadImage
{
    public static class ReadImage
    {

        public static async Task<string> readImage(IFormFile file)
        {
            string[] allowedExtension = new[] { ".jpg", ".png", ".jpeg", ".webp" };
            // resmin uzantısını alma && kontrol etme
            var extension = Path.GetExtension(file.FileName);
            // random bir isim oluşturma
            var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");
            // kaydedilecek dosyanın yolunu oluşturma;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", randomFileName);
            if (file != null)
            {
                if (!allowedExtension.Contains(extension))
                {
                    return null;
                }
            }

            using (var stream = new FileStream(path, FileMode.Create))
                await file.CopyToAsync(stream);


            return randomFileName; ;


        }


    }
}
