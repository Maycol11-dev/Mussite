<script>
  import Cabecera from "./Cabecera.svelte";
  
  
</script>

<Cabecera />

<div class="container-fluid m-0 p-0">
  <div class=" w-100 d-flex mt-5 justify-content-center">
    <div class="presentacion d-flex w-75">
      <div class="logo mt-5">
        <img
          src="../src/assets/IconoParaInicio.png"
          width="400rem"
          height="300rem"
          alt="Logo de la página"
        />
      </div>

      <div class="ms-5 justify-content-center">
        <div class="vr" style="height: 100%;"></div>
      </div>

      <div class="informacion p-5">
        <h3>Presentación</h3>
        <p>
          Mussite es una plataforma digital dedicada a la clasificación, organización y distribución
          de partituras y tablaturas musicales. Nuestro objetivo es ofrecer a estudiantes, docentes, entre otros,
          un espacio rápido, simple e intuitivo donde puedan encontrar material musical según su tipo de
          notación, el instrumento para el que fue compuesto y preferencias de búsqueda personalizadas.
        </p>
      </div>
    </div>
  </div>

  <div class="contenidos mt-5">
      <div class="d-flex justify-content-center">
        <h3 style="border-bottom: 3px solid #00c3ff">Bandas músicales</h3>
      </div>
      <div class="bandas d-flex">
        <div class="imagen">
          <img src="src/assets/banda.jpg" alt="foto de banda" />
        </div>
        <div class="informacion p-5 me-5 ms-5">
          <p>Los músicos y amantes de la música pueden descubrir y seguir bandas de distintos géneros y estilos. La plataforma permite que los artistas compartan sus composiciones, colaboren con otros músicos y creen espacios de interacción y aprendizaje. Nuestros usuarios pueden explorar nuevas bandas, ver fragmentos de partituras y tablaturas, conocer a sus integrantes y descubrir el estilo musical de cada banda, además de fomentar la participación de la comunidad a través de comentarios, valoraciones y recomendaciones, generando un ambiente donde tanto principiantes como profesionales pueden aprender, inspirarse y conectar con otros músicos.</p>
        </div>
      </div>
    
    <div class="d-flex justify-content-center">
        <h3 style="border-bottom: 3px solid #00c3ff">Galería de Partituras</h3>
      </div>
      <div class="galeriaDePartituras d-flex">
        <div class="informacion p-5 ms-5 me-5">
          <p>Ofrecemos una galería de partituras con un extenso repertorio de composiciones, desde obras clásicas hasta tablaturas modernas de distintos instrumentos. Nuestros usuarios pueden filtrar el contenido por tipo de notación, instrumento, compositor y popularidad, facilitando la búsqueda de material específico para estudio o interpretación. Cada partitura incluye su respectiva portada y archivo PDF permitiendo a los músicos descargar, visualizar e imprimir sus obras favoritas de manera sencilla y rápida. Nuestra plataforma también incentiva la colaboración entre los usuarios, ya que pueden compartir partituras propias, valorar el trabajo de otros y descubrir nuevas composiciones que se adapten a sus intereses y nivel musical.</p>
        </div>
        <div class="imagen">
          <img src="src/assets/galeria.jpg" width="612px" height="387px" alt="foto de partitura" />
        </div>
      </div>
  </div>
</div>

<style>
  .presentacion {
    display: flex;
    border: 3px solid #00c3ff;
    border-radius: 50px;
  }
  .informacion p {
    font-size: 20px;
  }

</style>
 