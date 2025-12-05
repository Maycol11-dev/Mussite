<script>
  import Cabecera from "./Cabecera.svelte";

  let noticias = [
    {
      titulo: "El Concurso Chopin de Polonia reúne a los jóvenes pianistas más brillantes en una batalla musical imperdible",
      fecha: "02/10/2025",
      descripcion: "Varsovia se convierte en el epicentro de la música clásica con la llegada de 84 talentos de 20 países, todos listos para conquistar el prestigioso Concurso Internacional de Piano Frederic Chopin y soñar con la gloria mundial",
      imagen: "src/assets/noticia4.avif"
    },
    {
      titulo: "Hallazgo: descubren un vals de Chopin de hace 200 años",
      fecha: "29/10/2024",
      descripcion: " Se descubrió un inédito y muy corto Vals en La menor (Valse en la mineur) de Frédéric Chopin en octubre de 2024, en la Biblioteca y Museo Morgan de Nueva York, por el curador Robinson McClellan",
      imagen: "src/assets/chopin.png"
    },
    {
      titulo: "Concurso nacional de composición de la Asociación Argentina de Compositores, junto a la Sinfónica de Salta y UCASAL",
      fecha: "01/07/2025",
      descripcion: "En el mes de julio, entre las actividades de la Asociación Argentina de Compositores se destaca el lanzamiento junto a la Orquesta Sinfónica de Salta y la Universidad Católica de Salta, del Primer Concurso Nacional de Composición.",
      imagen: "src/assets/noticia2.png"
    },
    {
      titulo: "Pilar Policano tocará en el Festival Konex de Música Clásica",
      fecha: "06/08/2025",
      descripcion: "Junto al Ensamble Estación Buenos Aires que dirige Rafael Gíntoli, la joven violinista argentina ofrecerá un programa con obras de Bach, Mozart, Beethoven y Mendelssohn. “Es un gran desafío, no sólo por las exigencias técnicas, sino también por la variedad de estilos que se conjugan”, destaca. ",
      imagen: "src/assets/noticia3.jpg"
    }
  ];
</script>

<Cabecera />

<h2 style="text-align:center; margin-top:2rem;">Noticias</h2>

<div class="noticias">
  {#each noticias as noticia}
    <div class="card">
      <img src={noticia.imagen} alt={noticia.titulo} />
      <div class="contenido p-3">
        <h3 class="mb-2 fs-5">{noticia.titulo}</h3>
        <p><strong>Fecha:</strong> {noticia.fecha}</p>
        <p>{noticia.descripcion}</p>
      </div>
    </div>
  {/each}
</div>

<style>
  .noticias {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: 1.5rem;
    padding: 2rem;
  }

  .card {
    border: 1px solid #ddd;
    border-radius: 8px;
    overflow: hidden;
    transition: transform 0.2s, box-shadow 0.2s;
    background: #fff;
  }

  .card:hover {
    transform: translateY(-5px);
    box-shadow: 0px 5px 15px rgba(0,0,0,0.2);
  }

  .card img {
    width: 100%;
    height: 150px;
    object-fit: cover;
  }

  .contenido p {
    margin: 0.3rem 0;
    font-size: 0.95rem;
  }
</style>
