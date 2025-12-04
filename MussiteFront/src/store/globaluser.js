import { writable } from "svelte/store";

export const user = writable({
  isLogged: false,
  idUsuario: 0,
  nombre: "",
  email: "",
  perfilUrl: "",
  bannerUrl: ""
});
