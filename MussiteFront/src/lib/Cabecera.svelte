<script>
  import { user } from "../store/globaluser.js";
  import { push } from "svelte-spa-router";

  let iniciarBuscador;
  let busqueda = "";

  let usuarios = [];
  let compositores = [];
  let resultados = [];

  async function abrirBuscador() {
    iniciarBuscador = true;

    
    const resUsers = await fetch("api/usuarios");
    usuarios = await resUsers.json();

    const resCompositores = await fetch("api/compositores");
    compositores = await resCompositores.json();
  
  }

  $: if (busqueda.length > 0) {
  if (busqueda.startsWith("u/")) {
    let term = busqueda.slice(2).toLowerCase();
    resultados = usuarios.filter(u =>
      u.nombre.toLowerCase().includes(term)
    );
  }

  if (busqueda.startsWith("c/")) {
    let term = busqueda.slice(2).toLowerCase();
    resultados = compositores.filter(c =>
      c.toLowerCase().includes(term)
    );
  }
}

$: if (busqueda.trim() === "") {
  resultados = [];
}

  function IrAComponente(componente) {
    push(componente);
  }

  function cerrarBuscador() {
  iniciarBuscador = false;
  busqueda = "";
  resultados = [];
}
</script>

<div class="header d-flex align-items-center justify-content-between w-100 p-1">
  <div class="logo d-flex ms-4">
    <img
      src="../src/assets/icons/Logoicon.png"
      width="50"
      height="45px"
      alt=""
    />
    <button on:click={() => IrAComponente("/Inicio")}>Mussite</button>
  </div>
  <div class="navegador d-flex align-items-center gap-3">
    <div>
      <img
        src="../src/assets/icons/buscaricono.png"
        width="50"
        height="45px"
        alt=""
      />
      <button on:click={abrirBuscador}>Buscar</button>
    </div>
    <div>
      <img
        src="../src/assets/icons/partituraicono.png"
        width="50"
        height="45px"
        alt=""
      />
      <button on:click={() => IrAComponente("/Partituras")}>Partituras</button>
    </div>
    <div>
      <img
        src="../src/assets/icons/comunidadicono2.png"
        width="60"
        height="px"
        alt=""
        class="mb-2"
      />
      <button on:click={() => IrAComponente("/Comunidad")}>Comunidad</button>
    </div>
    <div>
      <img
        src="../src/assets/icons/noticiasicono.png"
        width="50"
        height="45px"
        alt=""
      />
      <button on:click={() => IrAComponente("/Noticias")}>Noticias</button>
    </div>
  </div>

  <div class="extremo me-1 d-flex">
    {#if $user.isLogged}
      <div class="user-menu d-flex align-items-center">
        <button on:click={() => IrAComponente("/Perfil")}>
          <img
            src={$user.perfilUrl}
            alt="Avatar"
            width="40"
            height="40"
            style="border-radius:50%; margin-right:8px;"
          />
          <span>{$user.nombre}</span>
        </button>
      </div>
    {:else}
      <button on:click={() => IrAComponente("/Login")}
        >Iniciar Sesión/Registrarse</button
      >
    {/if}
  </div>

  {#if iniciarBuscador}
    <div class="modal-backdrop">
      <div class="modal-window">
        <div class="d-flex justify-content-between">
          <h3>Buscador</h3>
          <div class="buttons">
            <button class="btn" on:click={cerrarBuscador}>
              <img
                src="src/assets/icons/cerrar-artguru.png"
                width="50px"
                height="50px"
                alt="Cerrar"
              />
            </button>
          </div>
        </div>

        <input type="text" class="form-control" placeholder="u/Usuario     g/Grupo     c/Compositor    g/Genero" bind:value={busqueda}/>

        <div class="contenido w-100 h-75 mt-3 p-2" style="overflow-y: auto">
          {#if resultados.length > 0}
            {#if busqueda.startsWith("c/")}
              {#each resultados as r}
                <div class="resultado-item">
                  <p>🎼 {r}</p>
                </div>
             {/each}
            {/if}

            {#if busqueda.startsWith("u/")}
              {#each resultados as r}
                <div class="resultado-item">
                  <p>👤 {r.nombre}</p>
                </div>
              {/each}
            {/if}
          {:else if busqueda.trim() !== ""}
            <p>No se encontraron resultados</p>
          {/if}
        </div>
      </div>
    </div>
  {/if}
</div>

<style>
  .logo button {
    background: none;
    border: none;
    padding: 0;
    margin: 0;
    font-size: 2rem;
    font-weight: bold;
    cursor: pointer;
    color: inherit;
    margin-bottom: 0.3rem;
  }
  .header {
    background-color: #00c3ff;
  }
  .navegador button,
  .extremo button {
    background: none;
    border: none;
    padding: 0;
    margin: 0;
    font-size: 1.25rem;
    font-family: "Trebuchet MS", "Lucida Sans Unicode", "Lucida Grande", "Lucida Sans", Arial, sans-serif;
    cursor: pointer;
    color: inherit;
    margin-bottom: 0.3rem;
    border-bottom: 2px solid transparent;
    transition: border-color 0.1s;
  }
  .navegador button:hover,
  .extremo button:hover {
    border-bottom-color: #ffffff;
  }
  .modal-backdrop {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.5);
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .modal-window {
    background: white;
    padding: 30px;
    height: 80%;
    width: 80%;
    border-radius: 8px;
  }

  .contenido {
    border-radius: 10px;
    border: 1px solid gray;
  }
</style>
