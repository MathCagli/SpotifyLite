import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { UsuarioService } from '../services/usuario.service';
import { PlanoService } from '../services/plano.service';
import { Usuario } from '../model/usuario';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from "@angular/flex-layout";
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { Plano } from '../model/plano';

@Component({
  selector: 'app-cadastrar',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, HttpClientModule, CommonModule, FlexLayoutModule],
  templateUrl: './cadastrar.component.html',
  styleUrl: './cadastrar.component.css'
})
export class CadastrarComponent implements OnInit {
  nome = new FormControl('', [Validators.required]);
  email = new FormControl('', [Validators.required]);
  senha = new FormControl('', [Validators.required]);
  dataNascimento = new FormControl('', [Validators.required]);
  planoId = new FormControl('', [Validators.required]);
  ativo = new FormControl('', [Validators.required]);
  limite = new FormControl('', [Validators.required]);
  numero = new FormControl('', [Validators.required]);
  errorMessage = '';
  usuario!: Usuario;
  listaPlanos: Plano[] = [];

  constructor(private usuarioService: UsuarioService, private planoService: PlanoService, private router: Router) {
  }
  ngOnInit(): void {

    this.planoService.listarPlanos().subscribe(response => {
      this.listaPlanos = response;
    });
  }

  public cadastrar() {
  }
}
