<script>
  import { user } from "../store/globaluser.js";
  import Cabecera from "./Cabecera.svelte";
  import SubirPartitura from "../lib/PerfilComp/SubirPartitura.svelte";
  import VerPerfil from "../lib/PerfilComp/VerPerfil.svelte";
  let vista = "VerPerfil";

  const componentes = { "VerPerfil" : VerPerfil,"SubirPartitura": SubirPartitura };
</script>

<Cabecera />

<div class="container d-flex ms-0 p-0 w-100">
  <div class="menuvertical col-2 p-3 ms-0 me-3">
    <div class="nombre">
      <h3>Configuración</h3>
      <ul class="opciones list-group ">
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => vista="VerPerfil"}>
            Ver Perfil
          </button>
        </li>
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => vista="EditarPerfil"}>
            Editar Perfil
          </button>
        </li>
        <li class="list-group-item list-group-item-action">
          <button type="button" class="list-group-item-action w-100 text-start" on:click={() => vista="SubirPartitura"}>
            Subir Partitura
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
  </div>

   <div class="ms-1">
    {#if vista === "VerPerfil"}
        <svelte:component this={componentes[vista]} user={$user}/>
    {/if}
    {#if vista === "SubirPartitura"}
        <svelte:component this={componentes[vista]} user={$user}/>
    {/if}
   </div>
</div>

<style>
  
  .menuvertical {
    border: 1px solid #ccc;
    min-height: 93vh;
  }
  .opciones li button{
    border: none;
    background: none;
  }
</style>
