import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { InicioComponent } from './inicio/inicio.component';
import { DetalheBandaComponent } from './detalhe-banda/detalhe-banda.component';
import { CadastrarComponent } from './cadastrar/cadastrar.component';

export const routes: Routes = [
    {
        path: '',
        component: LoginComponent
    },
    {
        path: 'inicio',
        component: InicioComponent
    },
    {
        path: 'cadastrar',
        component: CadastrarComponent
    },
    {
        path: 'detalhe/:id',
        component: DetalheBandaComponent
    }
];
