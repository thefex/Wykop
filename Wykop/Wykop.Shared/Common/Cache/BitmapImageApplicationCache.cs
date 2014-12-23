using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Wykop.Common.Cache
{
    /// <summary>
    ///     This class exists to cache frequently used images (for instance in animation)
    ///     Reason: if images aren't cached they "blink" on load - animations quality is decreased.
    /// </summary>
    public class BitmapImageApplicationCache
    {
        private static readonly InMemoryRandomAccessStream EmptyImageStream = new InMemoryRandomAccessStream();
        private readonly Dictionary<Uri, BitmapImage> _loadedImages;

        public BitmapImageApplicationCache()
        {
            _loadedImages = new Dictionary<Uri, BitmapImage>();
        }

        public async Task AddImageToCache(Uri imageSource)
        {
            if (_loadedImages.ContainsKey(imageSource))
                return;

            var bitmapImage = new BitmapImage();
            var imageFile = await StorageFile.GetFileFromApplicationUriAsync(imageSource);
            bitmapImage.SetSource(await imageFile.OpenReadAsync());

            _loadedImages.Add(imageSource, bitmapImage);
        }

        public bool HasImageInCache(Uri imageSource)
        {
            return _loadedImages.ContainsKey(imageSource);
        }

        public BitmapImage GetImage(Uri imageSource)
        {
            if (!HasImageInCache(imageSource))
                throw new InvalidOperationException("There is no image in cache.");

            return _loadedImages[imageSource];
        }

        public void UnloadAllImages()
        {
            foreach (var image in _loadedImages.Values)
                image.SetSource(EmptyImageStream);
            _loadedImages.Clear();
        }
    }
}