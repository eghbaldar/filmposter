// Developed by: ALIMOHAMMAD EGHBALDAR // www.eghbaldar.ir //
const KingGalleryImages = document.querySelectorAll('.gallery-image');
const Kinglightbox = document.getElementById('Kinglightbox');
const KinglightboxImage = document.getElementById('Kinglightbox-image');
const KingcloseBtn = document.querySelector('.KinglightboxClose');
const KingprevBtn = document.getElementById('KinglightboxPrev');
const KingnextBtn = document.getElementById('KinglightboxNext');

var srcValues = [];
var KingLightBocCurrentIndex = 0;
var holderRootPath;

function setUniquePostPhotosId(id_photo, rootPath, id_post) {

    Kinglightbox.style.display = 'flex';
    var firstSelectedPhoto = $("#imgPostPhotos_" + id_photo.toString()).attr("data-src");
    holderRootPath = rootPath;
    KingLightboxShowImage(firstSelectedPhoto, rootPath); // load the first one

    const images = document.querySelectorAll("#item_" + id_post + " img");
    srcValues = [];
    images.forEach((image, index) => {
        const src = image.getAttribute('data-src');
        const imageInfo = {
            index: index,
            src: src
        };
        srcValues.push(imageInfo);        
    });
    KingLightBocCurrentIndex = findIndexBySrc(srcValues, firstSelectedPhoto);
    // if there is only one element in array, the NEXT and PREVIOUS buttons will be invisibled!
    if (srcValues.length == 1) {
        KingnextBtn.style.display = "none";
        KingprevBtn.style.display = "none";
    }
    else {
        KingnextBtn.style.display = "block";
        KingprevBtn.style.display = "block";
    }
}
// Function to find the index based on src value
function findIndexBySrc(arr,src) {
    const foundIndex = arr.findIndex(element => element.src === src);
    return foundIndex;
}
function KingLightboxShowImage(filename, rootPath) {
    setTimeout(() => {
        KinglightboxImage.setAttribute('src', rootPath + '/' + filename + '-original.jpg');
    }, 1);
}
function KingLightboxShowImageSeeker(filename) {
    setTimeout(() => {
        KinglightboxImage.setAttribute('src', holderRootPath + '/' + filename + '-original.jpg');
    }, 1);
}
// Previous image
KingprevBtn.addEventListener('click', () => {
    KingLightBocCurrentIndex = (KingLightBocCurrentIndex - 1 + srcValues.length) % srcValues.length;
    KingLightboxShowImageSeeker(srcValues[KingLightBocCurrentIndex].src);
});
// Next image
KingnextBtn.addEventListener('click', () => {
    KingLightBocCurrentIndex = (KingLightBocCurrentIndex + 1) % srcValues.length;
    KingLightboxShowImageSeeker(srcValues[KingLightBocCurrentIndex].src);
});
// Close when is clicked on background
Kinglightbox.addEventListener('click', (event) => {
    if (event.target === Kinglightbox) {
        Kinglightbox.classList.remove('KinglightboxOpen');
        Kinglightbox.style.display = 'none';
    }
});
// Close with btnClose
KingcloseBtn.addEventListener('click', () => {
    Kinglightbox.style.display = 'none';
});
// Event listener for the left and right arrow keys
document.addEventListener('keydown', (event) => {
    if (event.key === 'ArrowLeft') {
        // Previous image
        currentIndex = (currentIndex - 1 + srcValues.length) % srcValues.length;
        KingLightboxShowImageSeeker(srcValues[currentIndex].src);
    } else if (event.key === 'ArrowRight') {
        // Next image
        currentIndex = (currentIndex + 1) % srcValues.length;
        KingLightboxShowImageSeeker(srcValues[currentIndex].src);
    }
    else if (event.key === 'Escape') {
        // Close modal
        Kinglightbox.style.display = 'none';
    }
});