using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.Common.UploadFile
{
    public class RequestUploadFileServiceDto
    {
        public bool Type { get; set; } //0=> photo 1=> other
        public string DirectoryROOT { get; set; } // W => wwwroot + W 
        public string DirectoryNameLevelParent { get; set; } // Y=> wwwroot + W + Y 
        public string DirectoryNameLevelChild { get; set; } // Z => wwwroot + W + Y + Z
        public IFormFile File { get; set; }
        public string[] Extension { get; set; } // acceptable extension
        public string FileSize { get; set; } // acceptable fileSize
        public long UsersId { get; set; }
        public Dictionary<string, string>? Scales { get; set; }
        // For example, if we want to create photos with different scales, we need to send: "{'original', '550'}, {'thumb', '150'}"
        // However, if you only desire to have one photo, simply pass a single scale: "{'original', '550'}"
        // Here, 150 represents the width, and the height is automatically determined based on the photo's aspect ratio.
        // The terms 'original' and 'thumb' are merely sample names for those scale; they hold no additional significance.
    }
}
