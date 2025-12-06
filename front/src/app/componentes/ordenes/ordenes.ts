import { Component, inject, OnInit, signal } from '@angular/core';
import { Orden } from '@interfaces/orden.interface';
import { OrdenService } from '@servicios/orden/orden.service';
import { UsuarioService } from '@servicios/usuario/usuario.service';
import { NgClass } from '@angular/common';
@Component({
  selector: 'app-ordenes',
  imports: [NgClass],
  templateUrl: './ordenes.html',
  styleUrl: './ordenes.css',
})
export class Ordenes implements OnInit{
    ordenService = inject(OrdenService);
    usuarioService = inject(UsuarioService);
    ordenes = signal<Orden[]>([]);
  
    ngOnInit(): void {
      const idCliente = this.usuarioService.obtenerUsuarioDeSesion();

      this.listarOrdenesDelUsuario(idCliente);
    }


    listarOrdenesDelUsuario(idCliente: number | null) {

      this.ordenService.obtenerOrdenesDelCliente(idCliente).subscribe({
        next: (data) => this.ordenes.set(data),
        error : (err) => console.log("ERROR AL OBTENER ORDENES DEL CLIENTE",err)
      })
    }

    
}
