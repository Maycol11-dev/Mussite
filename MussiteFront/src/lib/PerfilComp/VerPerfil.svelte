<script>
    export let user;
</script>

<div class="fondo mb-4">
    <img src={user.bannerUrl} alt="Fondo de perfil" />
</div>
<div class="cuenta d-flex">
    <div class="perfil me-5">
        <img
            src={user.perfilUrl}
            alt="Logo de perfil"
        />
        <div class="ms-3">
            <h3>{user.nombre}</h3>
            <h5>u/{user.nombre}</h5>
        </div>
    </div>
    <div class="perfilinformation row-1">
        <p>
            𝐀𝐥𝐰𝐚𝐲𝐬 𝐌𝐮𝐬𝐢𝐜 🎧✨<br /> 영상은 분위기에 맞는 장면을 큐레이션하고,
            음향 및 시각 효과를 통해 편집한 창작 콘텐츠입니다. 무단 재업로드 및
            2차 제작은 금지되어 있습니다. <br />📩 문의: onulbusiness@gmail.com
            <br />
            <br />
            Enlaces
            <br />
            Spotify : open.spotify.com/artist/2DY4f01xP79FP8CiiDykUq
            <br />
            Apple Music : music.apple.com/kr/artist/soft-eraser/1844259748
            <br />
            Youtube Music : music.youtube.com/channel/UCgylSIoKccWRFIoKVuI4gfQ?si=HgCwUX7sTDt9bvlb
            <br />
            <br />
            Más información
            <br />
            www.youtube.com/@softeraser-m7h
            <br />
            Se unió el 25 ene 2016
            <br />
            7,39 K suscriptores
            <br />
            94 vídeos
            <br />
            523.830 visualizaciones
        </p>
    </div>
</div>
<hr />
<div class="contenidos d-flex gap-4 justify-content-center">
    <h5>Publicaciones</h5>
    <h5>Favoritos</h5>
    <h5>Guardados</h5>
    <h5>Partituras</h5>
    <h5>Videos</h5>
    <h5>Comentarios</h5>
    <h5>Suscripciones</h5>
</div>
<hr />
<div class="galeria">
    <p>asd</p>
</div>

<style>
    .fondo {
        height: 365px;
        overflow: hidden;
    }
    .fondo img {
        border-radius: 20px;
        width: 100%;
        height: 100%;
        object-fit: cover;
        object-position: top;
    }
    .perfil img {
        border-radius: 100%;
        width: 160px;
        height: 160px;
    }
</style>
