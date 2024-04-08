import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Banda } from '../model/banda';
import { BandaService } from '../services/banda.service';
import { Album, Musica } from '../model/album';
import { MatExpansionModule } from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-detalhe-album',
  standalone: true,
  imports: [FormsModule, MatButtonModule, MatInputModule, MatFormFieldModule, MatCardModule, MatExpansionModule, CommonModule],
  templateUrl: './detalhe-album.component.html',
  styleUrl: './detalhe-album.component.css'
})
export class DetalheAlbumComponent implements OnInit {
  idAlbum = '';
  busca = '';
  musicas: Musica[] = [];
  todasMusicas: Musica[] = [];

  constructor(private route: ActivatedRoute, private bandaService: BandaService) { }

  ngOnInit(): void {
    this.idAlbum = this.route.snapshot.params["id"];
    let idUsuario = localStorage.getItem("user");
    this.bandaService.listarMusicas(idUsuario as string, this.idAlbum).subscribe(response => {
      this.todasMusicas = response;
      this.musicas = response;
    });
  }

  public buscar() {
    this.musicas = this.todasMusicas.filter(i => i.nome?.includes(this.busca));
  }

  public favoritar(item: Musica) {
    item.favorito = true;
  }

  public desfavoritar(item: Musica) {
    item.favorito = false;
  }
}
