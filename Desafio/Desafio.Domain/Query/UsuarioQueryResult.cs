﻿namespace Desafio.Domain.Query
{
    public class UsuarioQueryResult
    {
        public long IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
    }
}
