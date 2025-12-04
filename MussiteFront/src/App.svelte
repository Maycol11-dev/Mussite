<script>
  import Router from "svelte-spa-router";

  import Login from './lib/Login.svelte';
  import Inicio from './lib/Inicio.svelte';
  import Noticias from './lib/Noticias.svelte';
  import Comunidad from './lib/Comunidad.svelte';
  import Partituras from './lib/Partituras.svelte';
  import Perfil from './lib/Perfil.svelte';

  const routes = {
    '/': Login,
    '/Login': Login,
    '/Inicio': Inicio,
    '/Noticias': Noticias,
    '/Comunidad': Comunidad,
    '/Partituras': Partituras,
    '/Perfil': Perfil,
  };
</script>

<Router {routes}/>