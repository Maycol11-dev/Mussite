<script>
  import { onMount } from "svelte";
  import Cabecera from "./Cabecera.svelte";

  let partituras = [];

  onMount(async () => {
    const response = await fetch("api/partituras");
    partituras = await response.json();
  });

  let tipo = "Todo";
  let instrumento = "";
  let buscar = "";

  const gruposInstrumentos = [
    {
      nombre: "Cuerdas",
      items: [
        { nombre: "Cello", tablatura: false },
        { nombre: "Guitarra", tablatura: true },
        { nombre: "Guitarra eléctrica", tablatura: true },
        { nombre: "Ukelele", tablatura: true },
        { nombre: "Bajo", tablatura: true },
        { nombre: "Banjo", tablatura: true },
        { nombre: "Violín", tablatura: false },
      ],
    },
    {
      nombre: "Teclado",
      items: [
        { nombre: "Piano", tablatura: false },
        { nombre: "Órgano", tablatura: false },
      ],
    },
    {
      nombre: "Percusión",
      items: [{ nombre: "Batería", tablatura: false }],
    },
    {
      nombre: "Viento / Metal",
      items: [
        { nombre: "Trompeta", tablatura: false },
        { nombre: "Trombón", tablatura: false },
        { nombre: "Saxofón", tablatura: false },
        { nombre: "Flauta", tablatura: false },
      ],
    },
  ];

  function abrirPDF(url) {
    window.open(url, "_blank");
  }

  $: partiturasFiltradas = partituras.filter(
    (p) =>
      p.titulo?.toLowerCase().includes(buscar.toLowerCase()) ||
      p.compositor?.toLowerCase().includes(buscar.toLowerCase()),
  );
</script>

<Cabecera />

<div class="preferencias ms-5 p-5">
  <h4>Preferencias</h4>
  <h5>Tipo</h5>
  
  <label><input type="radio" name="tipo" bind:group={tipo} value="Todo" /> Todo</label>
  <label><input type="radio" name="tipo" bind:group={tipo} value="Partitura" /> Partitura</label>
  <label><input type="radio" name="tipo" bind:group={tipo} value="Tablatura" /> Tablatura</label>

  <h5>Orden</h5>
  <label><input type="radio" name="orden" /> Alfabéticamente</label>
  <label><input type="radio" name="orden" /> Recientes</label>
  <label><input type="radio" name="orden" /> Más vistos</label>
  <h5>Instrumento</h5>
  {#each gruposInstrumentos as grupo}
    <h6>{grupo.nombre}</h6>
    <div class="d-flex gap-1">
      {#each grupo.items as inst}
        <label>
          <input
            type="radio"
            name="instrumento"
            bind:group={instrumento}
            value={inst.nombre}
            disabled={tipo === "Tablatura" && !inst.tablatura}
          />
          {inst.nombre}
        </label>
      {/each}
    </div>
  {/each}
</div>

<h4 class="ms-5 ps-5">Iniciar búsqueda</h4>

<div class="buscador ms-5 mt-3 ps-5 w-50">
  <input
    type="text"
    placeholder=" Buscar por título o compositor"
    bind:value={buscar}
    class="form-control"
  />
</div>

<div class="separador ms-5 ps-5">
  <br />
  <hr />
</div>

<div class="galeria">
  {#each partiturasFiltradas as p}
    <button
      class="card"
      on:click={() => abrirPDF("http://localhost:5285" + p.pdfUrl)}
    >
      <img src={"http://localhost:5285" + p.imagenUrl} alt={p.Titulo} />
      <h5>{p.compositor} - {p.titulo}</h5>
    </button>
  {/each}
</div>

<style>
  .separador {
    width: 92.3%;
  }
  .galeria {
    display: grid;
    grid-template-columns: repeat(auto-fill, 200px);
    gap: 1rem;
    padding: 1rem;
    justify-content: center;
  }

  .card {
    cursor: pointer;
    background: #fff;
    padding: 0.5rem;
    text-align: center;
    border: 1px solid #ddd;
    transition: 0.2s;
  }

  .card:hover {
    transform: scale(1.05);
    border-color: #00c3ff;
  }

  .card img {
    width: 100%;
  }
</style>
