import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../model/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private url = "https://localhost:7154/api/Usuario"

  constructor(private http: HttpClient) { }

  public autenticar(email: String, senha: String): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}/login`, {
      email: email,
      senha: senha
    });
  }

  public cadastrar(nome: string, email: String, senha: String, dataNascimento: Date, planoId: String, limite: number, numero: String): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}`, {
      nome: nome,
      email: email,
      senha: senha,
      dataNascimento: dataNascimento,
      planoId: planoId,
      cartao: {
        ativo: true,
        limite: limite,
        numero: numero
      }
    });
  }
}