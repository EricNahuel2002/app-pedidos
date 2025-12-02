import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Menu } from '@interfaces/menu.interface';
import { InicioService } from '@servicios/inicio/inicio.service';





@Component({
  selector: 'app-inicio',
  imports: [CommonModule],
  templateUrl: './inicio.html',
  styleUrls: ['./inicio.css'],
})
export class Inicio implements OnInit{

  menus = signal<Menu[]>([]);
  layout: 'list' | 'grid' = 'list';
  options = ['list', 'grid'];


  inicioService = inject(InicioService);

  ngOnInit(): void {
    this.listarMenus();
  }

  listarMenus(){
    this.inicioService.listarMenus().subscribe({
      next: (data) => {
        this.menus.set(data);
      },
      error: (data) => {
        console.log("ERROR AL TRAER LOS MENUS",data)
      }
    })
  }

  seleccionar(id: number){

  }

}
