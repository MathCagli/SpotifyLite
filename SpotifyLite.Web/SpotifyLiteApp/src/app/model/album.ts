export interface Album {
    id?:string;
    nome?:string;
    musicas?: Musica[]
}

export interface Musica {
    id?:string;
    idPlaylist?:string;
    nome?:string;
    duracao?:string;
    favorito?:boolean;
}