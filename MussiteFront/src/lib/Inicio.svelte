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
        <div class="info ms-5 p-2">
          <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Similique, impedit. Possimus amet, natus similique odio explicabo ducimus est assumenda cupiditate, vel aperiam suscipit velit fugiat porro? Nesciunt dolorem nulla ipsum.</p>
        </div>
      </div>
    
    <div class="d-flex justify-content-center">
        <h3 style="border-bottom: 3px solid #00c3ff">Galería de Partituras</h3>
      </div>
      <div class="galeriaDePartituras d-flex">
        <div class="info ms-5 p-2">
          <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Similique, impedit. Possimus amet, natus similique odio explicabo ducimus est assumenda cupiditate, vel aperiam suscipit velit fugiat porro? Nesciunt dolorem nulla ipsum.</p>
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
 