import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { UsuarioService } from '../services/usuario.service';
import { PlanoService } from '../services/plano.service';
import { Usuario } from '../model/usuario';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from "@angular/flex-layout";
import { Router } from '@angular/router';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDateModule } from '@angular/material/core';
import { Plano } from '../model/plano';

@Component({
  selector: 'app-cadastrar',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatDatepickerModule, MatNativeDateModule, MatSelectModule, ReactiveFormsModule, MatButtonModule, MatCardModule, HttpClientModule, CommonModule, FlexLayoutModule],
  templateUrl: './cadastrar.component.html',
  styleUrl: './cadastrar.component.css'
})
export class CadastrarComponent implements OnInit {
  nome = new FormControl('', [Validators.required]);
  email = new FormControl('', [Validators.required]);
  senha = new FormControl('', [Validators.required]);
  dataNascimento = new FormControl('', [Validators.required]);
  planoId = new FormControl('', [Validators.required]);
  limite = new FormControl('', [Validators.required]);
  numero = new FormControl('', [Validators.required]);
  errorMessage = '';
  usuario: {};
  listaPlanos: Plano[] = [];

  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService, private planoService: PlanoService, private router: Router) {
  }

  ngOnInit(): void {
    this.planoService.listarPlanos().subscribe(response => {
      this.listaPlanos = response;
    });
  }

  public cadastrar() {
    this.usuarioService.cadastrar(
      this.nome.value as string,
      this.email.value as string,
      this.senha.value as string,
      new Date(this.dataNascimento.value as string),
      this.planoId.value as string,
      parseFloat(this.limite.value as string),
      this.numero.value as string
    ).subscribe(
      {
        next: (response) => {
          this.usuario = response;
          sessionStorage.setItem("user", JSON.stringify(this.usuario));
          this.router.navigate(["/inicio"]);
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = e.error.error;
          }
        }
      });
  }
}
