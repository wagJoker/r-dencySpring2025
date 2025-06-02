import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Booking } from '../models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private apiUrl = 'http://localhost:3000/bookings';

  constructor(private http: HttpClient) {}

  createBooking(booking: Booking): Observable<Booking> {
    return this.http.post<Booking>(this.apiUrl, booking);
  }

  getBookings(): Observable<Booking[]> {
    return this.http.get<Booking[]>(this.apiUrl);
  }

  getBooking(id: string): Observable<Booking> {
    return this.http.get<Booking>(`${this.apiUrl}/${id}`);
  }

  updateBooking(id: string, booking: Partial<Booking>): Observable<Booking> {
    return this.http.patch<Booking>(`${this.apiUrl}/${id}`, booking).pipe(
      catchError(error => {
        if (error.status === 409) {
          throw new Error('Booking time conflict: The selected time slot is already booked');
        }
        throw error;
      })
    );
  }

  checkBookingConflict(workspaceId: string, date: Date, startTime: string, endTime: string): Observable<boolean> {
    const params = new HttpParams()
      .set('workspaceId', workspaceId)
      .set('date', date.toISOString())
      .set('startTime', startTime)
      .set('endTime', endTime);

    return this.http.get<boolean>(`${this.apiUrl}/check-conflict`, { params });
  }

  deleteBooking(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }