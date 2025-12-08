
const slides = document.querySelectorAll('.slides-wrapper img');
const wrapper = document.getElementById('slides');
const dotsContainer = document.getElementById('dots');
let currentIndex = 0;
let autoSlideInterval;

// 1. Create Dots based on number of images
slides.forEach((_, index) => {
    const dot = document.createElement('div');
    dot.classList.add('dot');
    if (index === 0) dot.classList.add('active');
    dot.addEventListener('click', () => goToSlide(index));
    dotsContainer.appendChild(dot);
});

const dots = document.querySelectorAll('.dot');

// 2. Main Function to update Slide Position
function updateSlider() {
    wrapper.style.transform = `translateX(-${currentIndex * 100}%)`;

    // Update Dots
    dots.forEach(dot => dot.classList.remove('active'));
    dots[currentIndex].classList.add('active');
}

// 3. Next/Prev Logic
function moveSlide(direction) {
    currentIndex += direction;

    // Loop back to start if at end
    if (currentIndex >= slides.length) {
        currentIndex = 0;
    }
    // Loop to end if at start
    else if (currentIndex < 0) {
        currentIndex = slides.length - 1;
    }

    updateSlider();
    resetTimer(); // Reset timer so it doesn't auto-slide immediately after a click
}

// 4. Jump to specific slide (Dot click)
function goToSlide(index) {
    currentIndex = index;
    updateSlider();
    resetTimer();
}

// 5. Auto Play Logic
function startTimer() {
    autoSlideInterval = setInterval(() => {
        moveSlide(1);
    }, 3000); // Change image every 3 seconds
}

function resetTimer() {
    clearInterval(autoSlideInterval);
    startTimer();
}

// Start the slideshow
startTimer();

// Optional: Pause on hover
const container = document.querySelector('.slider-container');
container.addEventListener('mouseenter', () => clearInterval(autoSlideInterval));
container.addEventListener('mouseleave', startTimer);


<<<<<<< HEAD

//script for hiding side bar

=======
//Sidebar Menu Handaling
>>>>>>> main
function openMenu() {
    document.querySelector(".sidebar").style.display = "grid";
}
function closeMenu() {
    document.querySelector(".sidebar").style.display = "none";
}
window.onresize = function () {
    if (window.innerWidth >= 1076) {
        document.querySelector(".sidebar").style.display = "none";
    }
};
