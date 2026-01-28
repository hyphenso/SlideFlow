const API_BASE = "http://localhost:5041";
const DEVICE_ID = 1;

async function loadSignage() {
  try {
    const response = await fetch(
      `${API_BASE}/api/show/active/${DEVICE_ID}`
    );

    if (!response.ok) {
      console.warn("No active content");
      return;
    }

    const data = await response.json();

    const img = document.getElementById("signage-image");
    img.src = `/media/${data.content.fileName}`;
    img.style.width = "100%";
    img.style.height = "100%";
    img.style.objectFit = "contain";

  } catch (error) {
    console.error("Failed to load signage:", error);
  }
}

// Load immediately
loadSignage();

// Refresh every 30 seconds
setInterval(loadSignage, 30000);
