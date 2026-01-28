const API_BASE = "http://localhost:5041";

document
  .getElementById("templates-btn")
  ?.addEventListener("click", loadTemplates);

async function loadTemplates() {
  const panel = document.getElementById("templates-panel");
  panel.style.display = "block";
  panel.innerHTML = "<p>Loading templates...</p>";

  try {
    const res = await fetch(`${API_BASE}/api/templates`);
    const templates = await res.json();

    panel.innerHTML = "";

    templates.forEach((t) => {
      const card = document.createElement("div");
      card.className = "template-card";
      card.innerHTML = `
        <img src="Media/${t.thumbnail}" />
        <p>${t.name}</p>
      `;

      card.onclick = () => applyTemplate(t);
      panel.appendChild(card);
    });
  } catch (err) {
    panel.innerHTML = "Failed to load templates";
    console.error(err);
  }
}
function applyTemplate(template) {
  const canvas = document.getElementById("canvas"); // or your editor area
  canvas.innerHTML = "";

  template.elements.forEach((el) => {
    if (el.type === "text") {
      const div = document.createElement("div");
      div.textContent = el.text;
      div.style.position = "absolute";
      div.style.left = el.x + "px";
      div.style.top = el.y + "px";
      canvas.appendChild(div);
    }

    if (el.type === "image") {
      const img = document.createElement("img");
      img.style.position = "absolute";
      img.style.left = el.x + "px";
      img.style.top = el.y + "px";
      img.style.width = el.width + "px";
      img.style.height = el.height + "px";
      canvas.appendChild(img);
    }
  });
}
