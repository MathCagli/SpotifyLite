import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Banda } from '../model/banda';
import { Album } from '../model/album';

@Injectable({
  providedIn: 'root',
  
})
export class BandaService {

  private url = "https://localhost:7154/api/Banda"

  constructor(private httpClient: HttpClient) { }

  public getBanda() : Observable<Banda[]> {
     return this.httpClient.get<Banda[]>(`${this.url}/ListarTodos`);
  }

  public getBandaPorId(id: string) : Observable<Banda> {
    return this.httpClient.get<Banda>(`${this.url}/ObterPorId/${id}`);
  }

  public getAlbunsBanda(id: string) : Observable<Album[]> {
    return this.httpClient.get<Album[]>(`${this.url}/ListarAlbuns/${id}/albums`);
  }

  public listarMusicas(idUsuario: string, idAlbum: string) : Observable<Album[]> {
    return this.httpClient.get<Album[]>(`${this.url}/ListarMusicas/${idUsuario}/albums/${idAlbum}`);
  }
}
