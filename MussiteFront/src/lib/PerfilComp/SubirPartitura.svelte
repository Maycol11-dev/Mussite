<script>
  export let user;

  let titulo = "";
  let compositor = "";
  let imagenFile;
  let pdfFile;
  let previewUrl = "";

  async function handleSubmit() {
    if (!titulo || !compositor || !imagenFile || !pdfFile) {
      alert("Completa todos los campos");
      return;
    }

    const formData = new FormData();
    formData.append("IdUsuario", user.idUsuario);
    formData.append("Titulo", titulo);
    formData.append("Compositor", compositor);
    formData.append("Imagen", imagenFile);
    formData.append("PDF", pdfFile);

    const res = await fetch("api/partituras/subir", {
      method: "POST",
      body: formData
    });

    if (res.ok) {
      alert("Partitura subida con éxito!");
      titulo = "";
      compositor = "";
      imagenFile = null;
      pdfFile = null;
      previewUrl = "";
    } 
    else {
         const errorData = await res.json();
         alert(`Error al subir la partitura: ${errorData.detail || errorData.title}`);
    }
  }

  function handleImageChange(event) {
    imagenFile = event.target.files[0];
    if (imagenFile) {
      previewUrl = URL.createObjectURL(imagenFile);
    }
  }

  function handlePdfChange(event) {
    pdfFile = event.target.files[0];
  }
</script>

<div class="subir-partitura">
  <h3>Subir nueva partitura</h3>
  <div class="form-group">
    <label for="titulo">Título</label>
    <input type="text" bind:value={titulo} placeholder="Título de la partitura" />
  </div>

  <div class="form-group">
    <label for="compositor">Compositor</label>
    <input type="text" bind:value={compositor} placeholder="Nombre del compositor" />
  </div>

  <div class="form-group">
    <label for="imagen">Imagen</label>
    <input type="file" accept="image/*" on:change={handleImageChange} />
    {#if previewUrl}
      <img src={previewUrl} alt="Preview" class="preview" />
    {/if}
  </div>

  <div class="form-group">
    <label for="pdf">PDF</label>
    <input type="file" accept="application/pdf" on:change={handlePdfChange} />
    {#if pdfFile}
      <p>Archivo seleccionado: {pdfFile.name}</p>
    {/if}
  </div>

  <button on:click={handleSubmit}>Subir Partitura</button>
</div>

<style>
.subir-partitura {
  max-width: 500px;
  margin: 2rem auto;
  padding: 1rem;
  border: 1px solid #ddd;
  border-radius: 8px;
  background: #fff;
}

.form-group {
  margin-bottom: 1rem;
}

input[type="text"], input[type="file"] {
  width: 100%;
  padding: 0.5rem;
  margin-top: 0.25rem;
}

.preview {
  margin-top: 0.5rem;
  width: 100%;
  max-height: 200px;
  object-fit: cover;
  border: 1px solid #ccc;
}

button {
  padding: 0.5rem 1rem;
  background-color: #00c3ff;
  border: none;
  color: #fff;
  cursor: pointer;
  border-radius: 4px;
  transition: 0.2s;
}

button:hover {
  background-color: #009ecf;
}
</style>
