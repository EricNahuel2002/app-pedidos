import { Routes } from '@angular/router';
import { Inicio } from './componentes/inicio/inicio';

export const routes: Routes = [
    {
        path : '',
        component : Inicio
    },
    {
        path : 'detalle-menu/:id',
        loadComponent : () => import("./componentes/detalle-menu/detalle-menu")
        .then(c => c.DetalleMenu)
    },
    {
        path : 'formulario-orden',
        loadComponent : () => import("./componentes/formulario-orden/formulario-orden")
        .then(c => c.FormularioOrden)
    },
    {
        path : 'ordenes',
        loadComponent : () => import("./componentes/orden/orden")
        .then(c => c.Orden)
    },
    {
        path : 'repartidor',
        loadComponent : () => import("./componentes/repartidor/repartidor")
        .then(c => c.Repartidor)
    }
];
