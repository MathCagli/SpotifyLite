import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { BandaService } from '../services/banda.service';
import { Banda } from '../model/banda';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from "@angular/flex-layout";
import { Router } from '@angular/router';

@Component({
  selector: 'app-inicio',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, HttpClientModule, CommonModule, FlexLayoutModule],
  templateUrl: './inicio.component.html',
  styleUrl: './inicio.component.css'
})
export class InicioComponent implements OnInit {

  bandas = null;

  constructor(private bandaService: BandaService, private router: Router) {
  }
  ngOnInit(): void {
    this.bandaService.getBanda().subscribe(response => {
      this.bandas = response as any;
    });
  }

  public verDetalhe(item:Banda) {
    this.router.navigate(["detalhe", item.id]);
  }
}
