import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Banda } from '../model/banda';
import { BandaService } from '../services/banda.service';
import { Album } from '../model/album';
import { MatExpansionModule } from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detalhe-banda',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, MatExpansionModule, CommonModule],
  templateUrl: './detalhe-banda.component.html',
  styleUrl: './detalhe-banda.component.css'
})
export class DetalheBandaComponent implements OnInit {
  idBanda = '';
  banda!:Banda;
  albuns!:Album[];

  constructor(private route: ActivatedRoute, private router: Router, private bandaService: BandaService) {  }
  
  ngOnInit(): void {
    this.idBanda = this.route.snapshot.params["id"];

    this.bandaService.getBandaPorId(this.idBanda).subscribe(response => {
      this.banda = response;
    });

    this.bandaService.getAlbunsBanda(this.idBanda).subscribe(response => {
      this.albuns = response;
    });
  }

  public verDetalhe(album:Album) {
    let idAlbum = album.id;
    this.router.navigate(["detalheAlbum", idAlbum]);
  }

}
