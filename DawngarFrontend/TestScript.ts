const canvas: any = document.getElementById("tutorial");
const ctx: any = canvas.getContext("2d");

const img: any = document.createElement("img");

img.onload = () => {
    ctx.drawImage(img, 0, 0);
};
img.src = "Aquatic.png";
