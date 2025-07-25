﻿using CRUDPersonaObjetos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaDAL.Repositorios.Persona
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly ProyectoPersonaContext _context;
        private readonly HttpClient _httpClient;

        public PersonaRepositorio(ProyectoPersonaContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }
        public async Task<CRUDPersonaObjetos.Modelos.Persona> ActualizarPersonaAsync(CRUDPersonaObjetos.Modelos.Persona persona)
        {
            /*var personaExistente = await _context.Personas.FindAsync(persona.Id); // otra forma de actualizar
            if (personaExistente != null)
            {
                personaExistente.Nombre = persona.Nombre;
                personaExistente.Apellido = persona.Apellido;
                personaExistente.Edad = persona.Edad;
                personaExistente.FechaRegistro = persona.FechaRegistro;
                await _context.SaveChangesAsync();
            }*/

            var existente = await _context.Persona.FindAsync(persona.Id);
            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(persona);
            _context.Entry(existente).Property(p => p.FechaRegistro).IsModified = false;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<CRUDPersonaObjetos.Modelos.Persona> CrearPersonaAsync(CRUDPersonaObjetos.Modelos.Persona persona)
        {
            //await _context.Personas.AddAsync(persona); // otra forma de guardar
            //await _context.SaveChangesAsync();

            /* _context.Persona.Add(persona);
                await _context.SaveChangesAsync();*/

            //API
            var response = await _httpClient.PostAsJsonAsync("/api/Persona", persona);

            response.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es exitosa

            var personaCreada = await response.Content.ReadFromJsonAsync<CRUDPersonaObjetos.Modelos.Persona>();

            return persona;
        }

        public async Task<bool> EliminarPersonaAsync(int id)
        {
            //var persona = await _context.Personas.FindAsync(id); // otra forma de eliminar
            //if (persona != null)
            //{
            //    _context.Personas.Remove(persona);
            //    await _context.SaveChangesAsync();
            //}

            /*var persona = await _context.Persona.FindAsync(id);
            if (persona == null) return false;

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();*/

            var response = await _httpClient.DeleteAsync($"/api/Persona/{id}"); //Eliminar no debe llevar un objeto, solo enviar el ID por URL

            response.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es exitosa

            var personaBorrada = await response.Content.ReadFromJsonAsync<bool>();

            return personaBorrada;
        }

        public async Task<CRUDPersonaObjetos.Modelos.Persona> ObtenerPersonaPorIdAsync(int id)
        {
            return await _context.Persona.FindAsync(id);
        }

        public async Task<List<CRUDPersonaObjetos.Modelos.Persona>> ObtenerPersonasAsync()
        {
            /*return await _context.Persona
                .Include(p => p.ProvinciaIdfkNavigation) // Incluye la relación con Provincia
                .ToListAsync();*/

            //API
            var listaPersonas = await _httpClient.GetFromJsonAsync<List<CRUDPersonaObjetos.Modelos.Persona>>("/api/Personas");


            return listaPersonas;

        }

    }
}
