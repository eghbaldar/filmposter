function KingSweetAlert(type, message) {

    if (type) { // success
        if (message == null) message = "اطلاعات با موفقیت انجام شد."
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });
        Toast.fire({
            icon: "success",
            title: message
        });
    } else { // error
        if (message == null) message = "خطایی پیش آمده است."
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 5000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });
        Toast.fire({
            icon: "error",
            title: message,
        });
    }
}
function KingSweetAlertTopRightLoading(message) {
    const Toast = Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timerProgressBar: true,
        didOpen: (toast) => {
            Swal.showLoading();
        }
    });
    Toast.fire({
        icon: "success",
        title: message
    });
}
function KingSweetStop() {
    Swal.close();
}
function KingSweetAlertTopRightTimer(message) {
    let timerInterval;
    const Toast = Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timerProgressBar: true,
        timer: 2000,
        didOpen: (toast) => {
            Swal.showLoading();
            const timer = Swal.getPopup().querySelector("b");
            timerInterval = setInterval(() => {
                timer.textContent = `${Swal.getTimerLeft()}`;
            }, 100);
        },
        willClose: () => {
            clearInterval(timerInterval);            
        }
    });
    Toast.fire({
        icon: "success",
        title: message
    });
}
function KingSweetAlertCenterTimer(object) {
    Swal.fire({
        title: object.title,
        html: object.message, // ✅ Now <b> exists
        timer: 5000,
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading();
            const timer = Swal.getPopup().querySelector("b"); // ✅ Now this works
            timerInterval = setInterval(() => {
                if (timer) {
                    timer.textContent = Swal.getTimerLeft(); // ✅ No more error
                }
            }, 100);
        },
        willClose: () => {
            clearInterval(timerInterval);
        }
    });

}
function KingSweetAlertCenterWithoutTimer(message) {
    // to stop the process use: "KingSweetStop();"
    let timerInterval;
    Swal.fire({
        html: message,
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading();
            const timer = Swal.getPopup().querySelector("b");
            timerInterval = setInterval(() => {
                timer.textContent = `${Swal.getTimerLeft()}`;
            }, 100);
        },
        willClose: () => {
            clearInterval(timerInterval);
        }
    }).then((result) => {
    });
}
function KingSweetAtCenter(title,message,icon) {
    Swal.fire({
        title: title,
        html: message,
        icon: icon, // success - error - warning - inco - question
        showCancelButton: false,
        showConfirmButton: true,
        confirmButtonText: ` متوجه شدم`,
        confirmButtonColor: "#008000",
    });
}