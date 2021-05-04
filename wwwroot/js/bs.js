[].forEach.call(document.getElementsByClassName('glow'), (el) => {
    el.onmousemove = function moveEvent(e) {
        // e = Mouse click event.
        var rect = e.target.getBoundingClientRect();
        var x = e.clientX - rect.left; //x position within the element.
        var y = e.clientY - rect.top;  //y position within the element.
        let glowing = e.target;
        glowing.style.backgroundImage = `radial-gradient(circle at top ${y}px left ${x}px, #FF385C 0%, #E61E4D 27.5%, #E31C5F 40%, #D70466 57.5%, #BD1E59 75%, #BD1E59 100%)`;
    }
});

$('.dropdown-toggle').dropdown()

