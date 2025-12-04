<script>
  import { onMount } from "svelte";
  import Cabecera from "./Cabecera.svelte";

  let partituras = [];

  onMount( async () =>{
    const response = await fetch("api/partituras");
    partituras = await response.json();
  });

  let tipo = "Todo";
  let instrumento = "";
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
      ]
    },
    {
      nombre: "Teclado",
      items: [
        { nombre: "Piano", tablatura: false },
        { nombre: "Órgano", tablatura: false },
      ]
    },
    {
      nombre: "Percusión",
      items: [
        { nombre: "Batería", tablatura: false },
      ]
    },
    {
      nombre: "Viento / Metal",
      items: [
        { nombre: "Trompeta", tablatura: false },
        { nombre: "Trombón", tablatura: false },
        { nombre: "Saxofón", tablatura: false },
        { nombre: "Flauta", tablatura: false },
      ]
    }
  ];

  function abrirPDF(url) {
    window.open(url, "_blank");
  }
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
  {/each}
</div>

<div class="galeria">
  {#each partituras as p}
    <button class="card" on:click={() => abrirPDF("http://localhost:5059" + p.pdfUrl)}>
      <img src={"http://localhost:5059" + p.imagenUrl} alt={p.Titulo} />
      <h5>{p.titulo}</h5>
    </button>
{/each}
</div>

<style>

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
