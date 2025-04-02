using Filmposter.Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.Common.UploadFile
{
    public class FileSignatureValidator
    {
        public static ResultDto ValidateFileSignatureByFile(IFormFile file)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Copy the contents of the IFormFile to the MemoryStream
                    file.CopyTo(ms);

                    // Get the bytes from the MemoryStream
                    byte[] fileBytes = ms.ToArray();

                    // Check the file signature
                    if (IsPDF(fileBytes) || IsMP3(fileBytes) || IsZIP(fileBytes) || IsRAR(fileBytes) || IsJPEG(fileBytes) || IsPNG(fileBytes)
                    || IsGIF(fileBytes) || IsBMP(fileBytes) || IsDoc(fileBytes) || IsTIFF(fileBytes) || IsHEIC(fileBytes) || IsOGG(fileBytes) || IsDOCX(fileBytes))
                    {
                        return new ResultDto
                        {
                            Message = "File signature is valid.",
                            IsSuccess = true,
                        };
                    }
                    else
                    {
                        return new ResultDto
                        {
                            Message = "Invalid file signature.",
                            IsSuccess = false,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    Message = "Error validating file signature: " + ex.Message,
                    IsSuccess = false,
                };
            }
        }

        public static ResultDto ValidateFileSignatureByFilePath(string filePath)
        {
            try
            {
                // Read the file contents
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Check the file signature
                if (IsPDF(fileBytes) || IsMP3(fileBytes) || IsZIP(fileBytes) || IsRAR(fileBytes) || IsJPEG(fileBytes) || IsPNG(fileBytes)
                    || IsGIF(fileBytes) || IsBMP(fileBytes) || IsDoc(fileBytes) || IsTIFF(fileBytes) || IsHEIC(fileBytes) || IsOGG(fileBytes) || IsDOCX(fileBytes))
                {
                    return new ResultDto
                    {
                        Message = "File signature is valid.",
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        Message = "Invalid file signature.",
                        IsSuccess = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    Message = "Error validating file signature: " + ex.Message,
                    IsSuccess = false,
                };
            }
        }

        private static bool IsPDF(byte[] header)
        {
            // Check if the file signature matches a PDF file
            return header[0] == 0x25 && header[1] == 0x50 && header[2] == 0x44 && header[3] == 0x46;
        }
        private static bool IsMP3(byte[] header)
        {
            if (header.Length < 2) return false; // Check if the header has at least two bytes to check for the MP3 signature 
            //return header[0] == 0xFF && (header[1] & 0xE0) == 0xE0;
            return header[0] == 0x49 && header[1] == 0x44 && header[2] == 0x33;
        }

        private static bool IsZIP(byte[] header)
        {
            // Check if the file signature matches a ZIP file
            // ZIP file signature: PKZIP file format signature (0x50 0x4B 0x03 0x04)
            return header[0] == 0x50 && header[1] == 0x4B && header[2] == 0x03 && header[3] == 0x04;
        }
        private static bool IsRAR(byte[] header)
        {
            // Check if the file signature matches a RAR file
            // RAR file signature: RAR file format signature (0x52 0x61 0x72 0x21)
            return header[0] == 0x52 && header[1] == 0x61 && header[2] == 0x72 && header[3] == 0x21;
        }
        private static bool IsJPEG(byte[] header)
        {
            // Check if the file signature matches a JPEG file
            return header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
        }
        private static bool IsPNG(byte[] header)
        {
            // Check if the file signature matches a PNG file
            return header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47 &&
                   header[4] == 0x0D && header[5] == 0x0A && header[6] == 0x1A && header[7] == 0x0A;
        }
        private static bool IsGIF(byte[] fileBytes)
        {
            return fileBytes.Length >= 3 && fileBytes[0] == 0x47 && fileBytes[1] == 0x49 && fileBytes[2] == 0x46;
        }
        private static bool IsBMP(byte[] fileBytes)
        {
            return fileBytes.Length >= 2 && fileBytes[0] == 0x42 && fileBytes[1] == 0x4D;
        }
        private static bool IsDoc(byte[] fileBytes)
        {
            return fileBytes.Length >= 8 && fileBytes[0] == 0xD0 && fileBytes[1] == 0xCF && fileBytes[2] == 0x11 && fileBytes[3] == 0xE0 && fileBytes[4] == 0xA1 && fileBytes[5] == 0xB1 && fileBytes[6] == 0x1A && fileBytes[7] == 0xE1;
        }
        private static bool IsTIFF(byte[] fileBytes)
        {
            return (fileBytes.Length >= 4 && ((fileBytes[0] == 0x49 && fileBytes[1] == 0x49 && fileBytes[2] == 0x2A && fileBytes[3] == 0x00) || (fileBytes[0] == 0x4D && fileBytes[1] == 0x4D && fileBytes[2] == 0x00 && fileBytes[3] == 0x2A)));
        }
        private static bool IsHEIC(byte[] fileBytes)
        {
            return fileBytes.Length >= 12 && fileBytes[4] == 0x66 && fileBytes[5] == 0x74 && fileBytes[6] == 0x79 && fileBytes[7] == 0x70 && fileBytes[8] == 0x68 && fileBytes[9] == 0x65 && fileBytes[10] == 0x69 && fileBytes[11] == 0x63;
        }
        private static bool IsOGG(byte[] header)
        {
            // Check if the file signature matches an OGG file
            return header.Length >= 4 && header[0] == 0x4F && header[1] == 0x67 && header[2] == 0x67 && header[3] == 0x53;
        }
        private static bool IsDOCX(byte[] header)
        {
            return header[0] == 0x50 && header[1] == 0x4B && header[2] == 0x03 && header[3] == 0x04 && header[4] == 0x14 && header[5] == 0x4E && header[6] == 0x6E && header[7] == 0x61;
        }
    }
}
