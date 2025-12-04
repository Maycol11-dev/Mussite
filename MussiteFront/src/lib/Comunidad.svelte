<script>
  import { user } from "../store/globaluser.js";
  import { push } from "svelte-spa-router";
  import Cabecera from "./Cabecera.svelte";

  import Curso from "./ComunidadComp/Curso.svelte";
  import Servicio from "./ComunidadComp/Servicio.svelte";

  let vista;
  let filtroCurso;

  function IrPerfil(componente) {
    if (!$user.isLogged){
      alert("Debes iniciar sesión para ver tu perfil.");
      return push("/Login");
    }

    push(componente);
  }
  const componentes = { Curso, Servicio };
</script>

<Cabecera />

<div class="container d-flex m-0 p-0">

  <div class="menuVertical col-3 p-3">
    <div class="mb-4">
      <div class="cuenta d-flex align-items-center mb-2">
        {#if ($user.isLogged)}
          <img
          class="me-3"
          src={"http://localhost:5285" + $user.perfilUrl}
          width="50px"
          height="50px"
          style={"border-radius: 100%"}
          alt="fotico de perfil"
          />
          <h5 class="mt-2 fw-bold">{$user.nombre}</h5>   
        {/if}
        
      </div>
      <ul class="opciones list-group ">
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => IrPerfil("/Perfil")}>
            Perfil
          </button>
        </li>
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => vista="MisPublicaciones"}>
            Tus publicaciones
          </button>
        </li>
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => vista="MisSeguidos"}>
            Siguiendo
          </button>
        </li>
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => vista="MisFavoritos"}>
            Favoritos
          </button>
        </li>
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => vista="MisGuardados"}>
            Guardados
          </button>
        </li>
      </ul>
    </div>

    <hr />
    <hr />

    <div class="curso mb-4">
      <h5 class="mb-2 fw-bold">Cursos</h5>
      <select class="form-select mb-2" bind:value={filtroCurso}>
        <option>General</option>
        <option>Piano</option>
        <option>Guitarra</option>
        <option>Violín</option>
        <option>Batería</option>
        <option>DAW</option>
      </select>
      <button class="btn btn-info w-100" on:click={() => (vista = "Curso")}
        >Filtrar</button
      >
    </div>

    <hr />

    <div class="servicios">
      <button class="mb-2 fw-bold" on:click={() => (vista = "Servicio")}
        >Servicios</button
      >
    </div>

    <hr>

    <div class="tienda">
      <button class="mb-2 fw-bold" on:click={() => (vista = "Tiendas")}
        >Tiendas</button
      >
    </div>
    <hr>
    <div class="mercado">
      <button class="mb-2 fw-bold" on:click={() => (vista = "Mercado")}
        >Mercado</button
      >
    </div>
  </div>


  <div class="contenidoDerecho col p-4">
    <svelte:component this={componentes[vista]} filtro={filtroCurso} />
  </div>

</div>

<style>
  .servicios button,
  .tienda button,
  .mercado button {
    font-size: 1.17rem;
    line-height: 1.2;
    background: none;
    border: none;
    padding: 0;
    margin: 0;
  }
  .menuVertical {
    border: 1px solid #ccc;
    min-height: 80vh;
  }
  
  .opciones li button{
    border: none;
    background: none;
  }

  h5 {
    font-family: "Trebuchet MS", sans-serif;
  }
</style>
