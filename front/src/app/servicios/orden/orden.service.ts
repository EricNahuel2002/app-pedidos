import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '@environment/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class OrdenService {

  private http = inject(HttpClient);
  
  
  ConfirmarOrden(idMenu: number, idUsuario: number) {
    return this.http.post(`${environment.BACKEND_URL}/ordenes/confirmarOrden`,{idMenu,idUsuario},{ responseType: 'text' as 'json' });
  }

}
