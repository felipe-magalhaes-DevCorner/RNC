namespace RNC.Exceptions
{
    public static class Thower
    {
        #region Thowers

        #endregion
        public static void BlackFieldThrower(string _string)
        {
            if (_string == null || _string == "")
            {
                throw new Exceptions.BlankFieldEx("Campo obrigatorio não preenchido!");

            }

        }




    }
}
