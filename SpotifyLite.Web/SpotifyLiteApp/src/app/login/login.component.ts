import { Component } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { UsuarioService } from '../services/usuario.service';
import { Usuario } from '../model/usuario';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatCardModule, FormsModule, ReactiveFormsModule, CommonModule, MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  senha = new FormControl('', [Validators.required]);
  errorMessage = '';
  usuario!: Usuario;

  constructor(private usuarioService: UsuarioService, private router: Router) {

  }

  public login() {
    if (this.email.invalid || this.senha.invalid) {
      return;
    }

    let emailValue = this.email.getRawValue() as String;
    let senhaValue = this.senha.getRawValue() as String;

    this.usuarioService.autenticar(emailValue, senhaValue).subscribe(
      {
        next: (response) => {
          this.usuario = response;
          localStorage.setItem("user", this.usuario.id as string);
          this.router.navigate(["/inicio"]);
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = e.error.error;
          }
        }
      });
  }

  public cadastrar() {
    this.router.navigate(["/cadastrar"]);
  }
}
