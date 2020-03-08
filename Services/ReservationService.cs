﻿using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;

namespace ChantemerleApi.Services
{
    public class ReservationService
    {
        readonly TokenService tokenService = new TokenService();
        readonly ReservationDao reservationDao = new ReservationDao();
        internal string validatDeleteReservationByModel(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            if (hasAdminInDatabaseOverApi)
            {
                response = ResponseR.success.ToString();
                reservationDao.deleteReservationByIdInDatabase(reservation.id);
            }

            return response;
        }

        internal string addPendingReservation(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            // admin adds a Reservation 

            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            if (hasAdminInDatabaseOverApi)
            {
            
                reservationDao.addPendingResevationByModelInDatbaseSoTheCustomerCanClaimIt(reservation);
                response = ResponseR.success.ToString();
            }

            return response;
        }

        internal string customerAcceptPendingReservationPotential(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));


            string response = ResponseR.fail.ToString();

            // token to user id here 

            double userId = tokenService.TokenToUserId(token);
            reservationDao.customerAcceptPendingReservationPotentialInDatabase(userId, reservation.id);

            return response;
        }

        internal string updateAcceptResevationByModel(string token, ReservationModel reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            if (hasAdminInDatabaseOverApi)
            {
                response = ResponseR.success.ToString();
                reservationDao.updateAcceptResevationByModelInDatbase(reservation.id);
            }

            return response;
        }

        internal string getPendingReservation()
        {
            const bool isAccepted = false;
            return validateGetReservation(isAccepted);
        }

        internal string getAccpetedReservation(string token)
        {
            const bool isAccepted = true;



            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            if (hasAdminInDatabaseOverApi)
            {

                response = validateGetReservation(isAccepted);
            }

            return response;

        }




        private string validateGetReservation(bool isAccepted)
        {

         
            string response = reservationDao.getReservations(isAccepted);

            return response;

        }

    }
}
