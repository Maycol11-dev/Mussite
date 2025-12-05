<script>
  import { user } from "../store/globaluser.js";
  import Cabecera from "./Cabecera.svelte";

  let loginEmail = "";
  let loginPassword = "";

  let registerUser = "";
  let registerEmail = "";
  let registerPassword = "";
  let registerError = "";

  let showModal = false;
  let recoveryEmail = "";

  async function handleLogin(event) {
    event.preventDefault();

      const response = await fetch("/api/account/Login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify({
          Email: loginEmail,
          Contrasena: loginPassword,
        }),
      });

      const data = await response.json();

      if (!response.ok) {
        console.log("Error en el servidor:", data);
        alert(data.message ?? "Error en el servidor");
        return;
      }

      user.set({
        isLogged: true,
        idUsuario: data.idUsuario,
        nombre: data.nombre,
        email: data.email,
        perfilUrl: "http://localhost:5285"+data.perfilUrl,
        bannerUrl: "http://localhost:5285"+data.bannerUrl
      });

      location.hash = "#/Inicio";
  }

  async function handleRegister(event) {
    event.preventDefault();

    registerError = "";

    try {
      const response = await fetch("/api/account/Register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          Nombre: registerUser,
          Email: registerEmail,
          Contrasena: registerPassword,
        }),
      });

      if (!response.ok) {
        const errorData = await response.json();
        console.log("Error en el servidor:", errorData);
        alert(errorData.message || "Error en el servidor");
        return;
      }

      registerError = "";
      console.log("Usuario registrado!");
    } catch (error) {
      console.error("Error: ", error);
      alert("Registro fallido.");
    }
  }
</script>

<Cabecera />

<div class="container">
  <div class="row justify-content-center align-items-center">
    <div class="col-md-5">
      <div class="card p-4 shadow">
        <h2 class="card-title text-center mb-4">Login</h2>
        <form on:submit={handleLogin}>
          <div class="mb-3">
            <label for="loginEmail" class="form-label">Email</label>
            <input
              type="email"
              id="loginEmail"
              bind:value={loginEmail}
              class="form-control"
              required
            />
          </div>
          <div class="mb-3">
            <div class="d-flex justify-content-between">
              <label for="loginPassword" class="form-label">Contraseña</label>
              <button
                type="button"
                class="btn btn-link p-0"
                on:click={() => (showModal = true)}
              >
                ¿Has olvidado la contraseña?
              </button>
            </div>
            <input
              type="password"
              id="loginPassword"
              bind:value={loginPassword}
              class="form-control"
              required
            />
          </div>
          <button class="google btn mb-2">
            <img
              src="/src/assets/icons/google.png"
              width="30px"
              height="30px"
              class="me-2"
              alt="Google icono"
            />
            Continuar con Google
          </button>
          <button class="btn btn-primary w-100" type="submit">Entrar</button>
        </form>
      </div>
    </div>

    {#if showModal}
      <div class="modal-backdrop">
        <div class="modal-window">
          <h3>Recuperar contraseña</h3>
          <label for="RecoveryEmail">Email</label>
          <input type="email" bind:value={recoveryEmail} class="form-control" />

          <div class="buttons mt-2">
            <button
              class="btn btn-secondary"
              on:click={() => (showModal = false)}>Cancelar</button
            >
            <button class="btn btn-primary">Enviar código</button>
          </div>
        </div>
      </div>
    {/if}

    <div class="col-md-1 d-none d-md-flex justify-content-center">
      <div class="vr" style="height: 300px;"></div>
    </div>

    <div class="col-md-5 mt-4 mt-md-0">
      <div class="card p-4 shadow">
        <h2 class="card-title text-center mb-4">Register</h2>
        <form on:submit={handleRegister}>
          <div class="mb-3">
            <label for="registerUser" class="form-label">Usuario</label>
            <input
              type="user"
              id="registerUser"
              bind:value={registerUser}
              class="form-control"
              required
            />
          </div>
          <div class="mb-3">
            <label for="registerEmail" class="form-label">Email</label>
            <input
              type="email"
              id="registerEmail"
              bind:value={registerEmail}
              class="form-control"
              required
            />
          </div>
          <div class="mb-3">
            <label for="registerPassword" class="form-label">Contraseña</label>
            <input
              type="password"
              id="registerPassword"
              bind:value={registerPassword}
              class="form-control"
              required
            />
          </div>
          <button class="google btn mb-2">
            <img
              src="/src/assets/icons/google.png"
              width="30px"
              height="30px"
              class="me-2"
              alt="Google icono"
            />
            Continuar con Google
          </button>
          <button class="btn btn-success w-100" type="submit"
            >Registrarse</button
          >
        </form>
        {#if registerError}
          <div class="alert alert-danger mt-2">
            {registerError}
          </div>
        {/if}
      </div>
    </div>
  </div>
</div>

<style>
  .google img {
    border-radius: 100%;
  }
  .google {
    border-radius: 30px;
    border: 1px solid rgb(224, 224, 224);
  }
  .container {
    margin-top: 13rem;
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
    padding: 20px;
    width: 400px;
    border-radius: 8px;
  }
</style>
