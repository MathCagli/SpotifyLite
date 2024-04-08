import { Cartao } from "./cartao";

export interface Usuario {
    id?:String;
    nome?:String;
    email?:String;
    senha?:String;
    dataNascimento?:String;
    planoId?:String;
    cartao?:Cartao;
}