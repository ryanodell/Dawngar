const canvas = document.getElementById('can') as HTMLCanvasElement;
const ctx = canvas.getContext('2d');
let selectedTileX = 0;
let selectedTileY = 0;
const tileSize = 16;
const img: any = document.createElement("img");

img.onload = () => {
    drawScene();
};
img.src = "../Assets/Characters/Cat.png";

// Camera properties
let cameraX = 0;
let cameraY = 0;
let cameraScale = 3;
let isDragging = false;
let dragStartX = 0;
let dragStartY = 0;

// Function to update the camera transformations
function updateCamera() {
  ctx.setTransform(1, 0, 0, 1, 0, 0); // Reset the transformation matrix
  ctx.translate(canvas.width / 2, canvas.height / 2); // Center the canvas
  ctx.scale(cameraScale, cameraScale); // Apply the camera scale
  ctx.translate(-cameraX, -cameraY); // Apply the camera position
}

// Example drawing function
function drawScene() {
  // Clear the canvas
  ctx.clearRect(0, 0, canvas.width, canvas.height);
   
  // Update the camera transformations
  updateCamera();

  ctx.imageSmoothingEnabled = false;
  
  // Draw objects in the camera space
  ctx.drawImage(img, 1, 1);

  const rectX = selectedTileX * tileSize;
  const rectY = selectedTileY * tileSize;
  ctx.strokeStyle = 'black';
  ctx.lineWidth = 1;
  ctx.strokeRect(rectX + 1, rectY + 1, tileSize, tileSize);
}

// Example event handlers for camera movement, zoom, and drag
document.addEventListener('keydown', (event) => {
  const cameraSpeed = 10;

  if (event.key === 'ArrowUp') {
    cameraY -= cameraSpeed;
  } else if (event.key === 'ArrowDown') {
    cameraY += cameraSpeed;
  } else if (event.key === 'ArrowLeft') {
    cameraX -= cameraSpeed;
  } else if (event.key === 'ArrowRight') {
    cameraX += cameraSpeed;
  }

  drawScene();
});

document.addEventListener('wheel', (event) => {
  const cameraZoomSpeed = 0.1;

  if (event.deltaY < 0) {
    cameraScale *= 1 + cameraZoomSpeed;
  } else {
    cameraScale *= 1 - cameraZoomSpeed;
  }

  drawScene();
});

canvas.addEventListener('mousedown', (event) => {
  if (event.button === 1) { // Check if the middle mouse button is pressed
    isDragging = true;
    dragStartX = event.clientX;
    dragStartY = event.clientY;
  }
});

function getWorldCoordinates(event) {
    const rect = canvas.getBoundingClientRect();
    const mouseX = event.clientX - rect.left;
    const mouseY = event.clientY - rect.top;
  
    // Apply inverse camera transformations
    const worldX = (mouseX - canvas.width / 2) / cameraScale + cameraX;
    const worldY = (mouseY - canvas.height / 2) / cameraScale + cameraY;
  
    return { x: worldX, y: worldY };
  }

canvas.addEventListener('mouseup', (event) => {
  isDragging = false;
});

canvas.addEventListener('click', (event) => {
    const { x, y } = getWorldCoordinates(event);
    if(x < 0 || y < 0) 
    {
        return;
    }
    // Calculate selected tile based on the clicked coordinates
    selectedTileX = Math.floor(x / tileSize);
    selectedTileY = Math.floor(y / tileSize);
  
    drawScene();
  });

canvas.addEventListener('mousemove', (event) => {
  if (isDragging) {
    const dragX = event.clientX - dragStartX;
    const dragY = event.clientY - dragStartY;
    cameraX -= dragX;
    cameraY -= dragY;
    dragStartX = event.clientX;
    dragStartY = event.clientY;
    drawScene();
  }
});

// Initial drawing
drawScene();
