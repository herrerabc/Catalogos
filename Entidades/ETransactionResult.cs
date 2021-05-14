using System;

namespace Entidades
{
    public class ETransactionResult
    {
        public string message { get; set; }
        public string rollbackMessage { get; set; }
        public int result { get; set; }
    }
}