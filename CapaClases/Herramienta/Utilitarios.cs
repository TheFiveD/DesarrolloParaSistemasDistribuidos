
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
public enum eMensajeTipo
{
    Msgerror, Msginfo, Msgexito, Msgalerta

}

//using CEntidad = CapaEntidades.GENE.Ent_CONFIG_CORREOS_MODULOS;
//using CLogica = CapaLogica.GENE.Log_CONFIG_CORREOS_MODULOS;

namespace Herramienta
{
    public class Utilitarios
    {
        //public void CorreoEnvioModulos(String COD_SMODULOS, Boolean IsBodyHtml, String Para, String ConCopia, String ConCopiaOculta, String Asunto, String MensajeTexto, String Attachments)
        //{
        //    try
        //    {
        //        List<CEntidad> loConfig = new List<CEntidad>();
        //        CEntidad oCampos = new CEntidad();
        //        CLogica oCLogica = new CLogica();
        //        //
        //        oCampos.COD_SMODULOS = COD_SMODULOS;
        //        loConfig = oCLogica.RegMostrarItems(oCampos);
        //        //
        //        if (loConfig.Count == 0)
        //        {
        //            throw new Exception("La cuenta de Correo para este Módulo no está Configurada");
        //        }
        //        using (MailMessage Message = new MailMessage())
        //        {
        //            String mDE = loConfig[0].MENSAJE_DE_CORREO;
        //            String mPara = loConfig[0].MENSAJE_PARA;
        //            String mConCopia = loConfig[0].MENSAJE_CC;
        //            String mConCopiaOculta = loConfig[0].MENSAJE_CCO;
        //            String mAsunto = loConfig[0].MENSAJE_ASUNTO;
        //            String mMensaje = loConfig[0].MENSAJE_TEXTO;
        //            //
        //            if (mPara != "" && Para != "") { mPara += "," + Para; }
        //            else { mPara += Para; }
        //            if (mConCopia != "" && ConCopia != "") { mConCopia += "," + ConCopia; }
        //            else { mConCopia += ConCopia; }
        //            if (mConCopiaOculta != "" && ConCopiaOculta != "") { mConCopiaOculta += "," + ConCopiaOculta; }
        //            else { mConCopiaOculta += ConCopiaOculta; }
        //            //
        //            //Validando Condiciones
        //            if (Asunto != "") { mAsunto += " " + Asunto; }
        //            if (MensajeTexto != "") { mMensaje += " " + MensajeTexto; }
        //            if (mPara == "" && mConCopia == "") //Caso que no tengan Correos las Persona
        //            {
        //                mPara = mDE;
        //                mAsunto = "(No Tiene Correo) " + mAsunto;
        //            }
        //            if (mPara == "" && mConCopia != "") //Caso Para No Correo y Con Copia Si
        //            {
        //                mPara = mConCopia;
        //                mConCopia = "";
        //            }
        //            Message.From = new MailAddress(mDE, loConfig[0].MENSAJE_DE_NOMBRE);
        //            //
        //            //Para if (mPara != "") { Message.To.Add(new MailAddress(mPara)); }
        //            mPara = ReemplaCarEspeciales(mPara);
        //            String[] sPa = mPara.Split(',');
        //            for (Int32 vFor = 0; vFor < sPa.Length; vFor++)
        //            {
        //                if (sPa[vFor].ToString() != "")
        //                {
        //                    Message.To.Add(new MailAddress(sPa[vFor]));
        //                }
        //            }
        //            //Con Copia if (mConCopia != "") { Message.CC.Add(new MailAddress(mConCopia)); }
        //            mConCopia = ReemplaCarEspeciales(mConCopia);
        //            String[] sCC = mConCopia.Split(',');
        //            for (Int32 vFor = 0; vFor < sCC.Length; vFor++)
        //            {
        //                if (sCC[vFor].ToString() != "")
        //                {
        //                    Message.CC.Add(new MailAddress(sCC[vFor]));
        //                }
        //            }
        //            //Copia Oculta
        //            mConCopiaOculta = ReemplaCarEspeciales(mConCopiaOculta);
        //            String[] sCCO = mConCopiaOculta.Split(',');
        //            for (Int32 vFor = 0; vFor < sCCO.Length; vFor++)
        //            {
        //                if (sCCO[vFor].ToString() != "")
        //                {
        //                    Message.Bcc.Add(new MailAddress(sCCO[vFor]));
        //                }
        //            }
        //            //
        //            Message.IsBodyHtml = IsBodyHtml;
        //            //
        //            if (loConfig[0].MENSAJE_PRIORIDAD == 0) { Message.Priority = MailPriority.Normal; }
        //            else if (loConfig[0].MENSAJE_PRIORIDAD == 1) { Message.Priority = MailPriority.Low; }
        //            else if (loConfig[0].MENSAJE_PRIORIDAD == 2) { Message.Priority = MailPriority.High; }
        //            //
        //            Message.Subject = mAsunto;
        //            Message.Body = mMensaje;
        //            //
        //            //Attachments
        //            if (Attachments != "")
        //            {
        //                String[] sAttachments = Attachments.Split('|');
        //                for (Int32 vFor = 0; vFor < sAttachments.Length; vFor++)
        //                {
        //                    if (sAttachments[vFor] != "")
        //                    {
        //                        Message.Attachments.Add(new Attachment(sAttachments[vFor]));
        //                    }
        //                }
        //            }
        //            //Configurando Servidor SMTP
        //            SmtpClient server = new SmtpClient();
        //            //server.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            if ((Boolean)loConfig[0].SERVER_CREDEN_ESTADO == true)
        //            {
        //                server.Credentials = new System.Net.NetworkCredential(mDE, loConfig[0].SERVER_CREDEN_PASSWORD);//dinamico imageninst
        //            }
        //            server.Host = loConfig[0].SERVER_SMTP;
        //            server.Port = loConfig[0].SERVER_SMTP_PUERTO;
        //            server.Send(Message);
        //            server = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void CorreoEnvioModulos(Boolean IsBodyHtml, String Para, String ConCopia, String ConCopiaOculta, String Asunto, String MensajeTexto,
                                        Object ConfSERVER_CREDEN_ESTADO, String ConfSERVER_CREDEN_PASSWORD, String ConfSERVER_SMTP, Int32 ConfSERVER_SMTP_PUERTO,
                                        String ConfMENSAJE_DE_CORREO, String ConfMENSAJE_DE_NOMBRE, String ConfMENSAJE_PARA, String ConfMENSAJE_CC,
                                        String ConfMENSAJE_CCO, String ConfMENSAJE_ASUNTO, String ConfMENSAJE_TEXTO, Int32 ConfMENSAJE_PRIORIDAD, String Attachments)
        {
            try
            {
                using (MailMessage Message = new MailMessage())
                {
                    String mDE = ConfMENSAJE_DE_CORREO;
                    String mPara = ConfMENSAJE_PARA;
                    String mConCopia = ConfMENSAJE_CC;
                    String mConCopiaOculta = ConfMENSAJE_CCO;
                    String mAsunto = ConfMENSAJE_ASUNTO;
                    String mMensaje = ConfMENSAJE_TEXTO;
                    //
                    if (mPara != "" && Para != "") { mPara += "," + Para; }
                    else { mPara += Para; }
                    if (mConCopia != "" && ConCopia != "") { mConCopia += "," + ConCopia; }
                    else { mConCopia += ConCopia; }
                    if (mConCopiaOculta != "" && ConCopiaOculta != "") { mConCopiaOculta += "," + ConCopiaOculta; }
                    else { mConCopiaOculta += ConCopiaOculta; }
                    //
                    //Validando Condiciones
                    if (Asunto != "") { mAsunto += " " + Asunto; }
                    if (MensajeTexto != "") { mMensaje += " " + MensajeTexto; }
                    if (mPara == "" && mConCopia == "") //Caso que no tengan Correos las Persona
                    {
                        mPara = mDE;
                        mAsunto = "(No Tiene Correo) " + mAsunto;
                    }
                    if (mPara == "" && mConCopia != "") //Caso Para No Correo y Con Copia Si
                    {
                        mPara = mConCopia;
                        mConCopia = "";
                    }
                    Message.From = new MailAddress(mDE, ConfMENSAJE_DE_NOMBRE);
                    //
                    //Para if (mPara != "") { Message.To.Add(new MailAddress(mPara)); }
                    mPara = ReemplaCarEspeciales(mPara);
                    String[] sPa = mPara.Split(',');
                    for (Int32 vFor = 0; vFor < sPa.Length; vFor++)
                    {
                        if (sPa[vFor].ToString() != "")
                        {
                            Message.To.Add(new MailAddress(sPa[vFor]));
                        }
                    }
                    //Con Copia if (mConCopia != "") { Message.CC.Add(new MailAddress(mConCopia)); }
                    mConCopia = ReemplaCarEspeciales(mConCopia);
                    String[] sCC = mConCopia.Split(',');
                    for (Int32 vFor = 0; vFor < sCC.Length; vFor++)
                    {
                        if (sCC[vFor].ToString() != "")
                        {
                            Message.CC.Add(new MailAddress(sCC[vFor]));
                        }
                    }
                    //Copia Oculta
                    mConCopiaOculta = ReemplaCarEspeciales(mConCopiaOculta);
                    String[] sCCO = mConCopiaOculta.Split(',');
                    for (Int32 vFor = 0; vFor < sCCO.Length; vFor++)
                    {
                        if (sCCO[vFor].ToString() != "")
                        {
                            Message.Bcc.Add(new MailAddress(sCCO[vFor]));
                        }
                    }
                    //
                    Message.IsBodyHtml = IsBodyHtml;
                    //
                    if (ConfMENSAJE_PRIORIDAD == 0) { Message.Priority = MailPriority.Normal; }
                    else if (ConfMENSAJE_PRIORIDAD == 1) { Message.Priority = MailPriority.Low; }
                    else if (ConfMENSAJE_PRIORIDAD == 2) { Message.Priority = MailPriority.High; }
                    //
                    Message.Subject = mAsunto;
                    Message.Body = mMensaje;
                    //
                    //Attachments
                    if (Attachments != "")
                    {
                        String[] sAttachments = Attachments.Split('|');
                        for (Int32 vFor = 0; vFor < sAttachments.Length; vFor++)
                        {
                            if (sAttachments[vFor] != "")
                            {
                                Message.Attachments.Add(new Attachment(sAttachments[vFor]));
                            }
                        }
                    }
                    //
                    //Configurando Servidor SMTP
                    SmtpClient server = new SmtpClient();
                    //server.DeliveryMethod = SmtpDeliveryMethod.Network;
                    if ((Boolean)ConfSERVER_CREDEN_ESTADO == true)
                    {
                        server.Credentials = new System.Net.NetworkCredential(mDE, ConfSERVER_CREDEN_PASSWORD);//dinamico imageninst
                    }
                    server.Host = ConfSERVER_SMTP;
                    server.Port = ConfSERVER_SMTP_PUERTO;
                    server.Send(Message);
                    server = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GrillaLlenar(GridView vGrilla, Object vTabla, Int32 vPaginaIndex)
        {
            vGrilla.DataSource = vTabla;
            //
            if (vPaginaIndex == -1)
            {
                vPaginaIndex = vGrilla.PageIndex;
            }
            else if (vPaginaIndex <-1)
            {
                vPaginaIndex = 0;
            }
            vGrilla.PageIndex = vPaginaIndex;
            vGrilla.DataBind();
            vGrilla.SelectedIndex = -1;
        }
        public void GrillaLimpiar(GridView vGrilla)
        {
            vGrilla.DataSource = null;
            vGrilla.DataBind();
        }
        public void GrillaAddMergedCells(GridViewRow objgridviewrow, TableCell objtablecell, int colspan, string celltext)
        {
            objtablecell = new TableCell();
            objtablecell.Text = celltext;
            objtablecell.ColumnSpan = colspan;
            objgridviewrow.Cells.Add(objtablecell);
        }
        public Int32 GrillaCheckSelect(GridView vGrilla, Int32 ColCheck)
        {
            CheckBox ChBSel;
            Int32 vCheckBoxSel = 0;
            foreach (GridViewRow GrillaFila in vGrilla.Rows)
            {
                ChBSel = (CheckBox)GrillaFila.Cells[ColCheck].Controls[1];
                if (ChBSel.Checked == true)
                {
                    vCheckBoxSel += 1;
                }
            }
            return vCheckBoxSel;
        }
        public String GrillaCheckSelectData(GridView vGrilla, Int32 ColCheck, Int32 ColData, String Separador)
        {
            CheckBox ChBSel;
            String DataGrilla = "";
            foreach (GridViewRow GrillaFila in vGrilla.Rows)
            {
                ChBSel = (CheckBox)GrillaFila.Cells[ColCheck].Controls[1];
                if (ChBSel.Checked == true)
                {
                    DataGrilla += GrillaFila.Cells[ColData].Text.Trim() + Separador;
                }
            }
            if (DataGrilla != "")
            {
                DataGrilla = DataGrilla.Substring(0, DataGrilla.Length - Separador.Length);
            }
            return DataGrilla;
        }
        public void DataListLlenar(DataList vGrilla, Object vTabla)
        {
            vGrilla.DataSource = vTabla;
            vGrilla.DataBind();
        }
        public void DataListLimpiar(DataList vGrilla)
        {
            vGrilla.DataSource = null;
            vGrilla.DataBind();
        }
        public void ComboLlenar(DropDownList vCombo, Object vTabla, String vDataValueField, String vDataTextField, Boolean vMostraPalabra_Seleccionar)
        {
            vCombo.DataSource = vTabla;
            vCombo.DataTextField = vDataTextField;
            vCombo.DataValueField = vDataValueField;
            vCombo.DataBind();
            //
            if (vMostraPalabra_Seleccionar)
            {
                vCombo.Items.Insert(0, new ListItem("(Seleccionar)", "-"));
            }
        }
        public void ComboLlenar(DropDownList vCombo, Object vTabla, String vDataValueField, String vDataTextField, String vValorDefecto)
        {
            vCombo.DataSource = vTabla;
            vCombo.DataTextField = vDataTextField;
            vCombo.DataValueField = vDataValueField;
            vCombo.DataBind();
            //
            vCombo.Items.Insert(0, new ListItem(vValorDefecto, "-"));
        }
        public void ComboLimpiar(DropDownList vCombo, bool vMostraPalabra_Seleccionar)
        {
            vCombo.DataSource = null;
            vCombo.DataTextField = null;
            vCombo.DataValueField = null;
            vCombo.DataBind();
            vCombo.Items.Clear();
            if (vMostraPalabra_Seleccionar)
            {
                vCombo.Items.Insert(0, new ListItem("(Seleccionar)", "-"));
            }
        }
        public void ComboDesactivarValor(DropDownList vCombo, String vDatoBuscar)
        {
            foreach (ListItem item in vCombo.Items)
            {
                if (item.Value != "-")
                {
                    if (vDatoBuscar.IndexOf(item.Value) != -1)
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }
        }
        public void ListBoxLlenar(ListBox vListBox, Object vTabla, String vDataValueField, String vDataTextField, bool vMostraPalabra_Seleccionar)
        {
            vListBox.DataSource = vTabla;
            vListBox.DataTextField = vDataTextField;
            vListBox.DataValueField = vDataValueField;
            vListBox.DataBind();
            //
            if (vMostraPalabra_Seleccionar)
            {
                vListBox.Items.Insert(0, new ListItem("(Seleccionar)", "-"));
            }
        }
        public void ListBoxLimpiar(ListBox vListBox, bool vMostraPalabra_Seleccionar)
        {
            vListBox.DataSource = null;
            vListBox.DataTextField = null;
            vListBox.DataValueField = null;
            vListBox.DataBind();
            vListBox.Items.Clear();
            if (vMostraPalabra_Seleccionar)
            {
                vListBox.Items.Insert(0, new ListItem("(Seleccionar)", "-"));
            }
        }
        public void ListBoxDesactivarValor(ListBox vLista, String vDatoBuscar)
        {
            foreach (ListItem item in vLista.Items)
            {
                if (item.Value != "-")
                {
                    if (vDatoBuscar.IndexOf(item.Value) != -1)
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }
        }

        public void LabelMensaje(Label vLabel, String vMensaje, Int32 TipoMsn)
        {
            String estilo = "error-msg";
            if (TipoMsn == 1) { estilo = "error-msg"; }
            else if (TipoMsn == 2) { estilo = "warning-msg"; }
            else if (TipoMsn == 3) { estilo = "information-msg"; }
            else if (TipoMsn == 5) { estilo = "confirmation-msg"; }
            vLabel.Text = "<div id='DivMensaje'><ul class='messages'><li class='" + estilo + "'>" + vMensaje + "</li></ul></div>";
        }

        public Boolean Directorio_Existe(String RutaNombre)
        {
            Boolean ReturnValue = Directory.Exists(RutaNombre);
            return ReturnValue;

        }
        public DirectoryInfo Directorio_Crear(String RutaNombre)
        {
            DirectoryInfo ReturnValue = Directory.CreateDirectory(RutaNombre);
            return ReturnValue;
        }
        public Boolean Directorio_Delete(String RutaNombre)
        {
            if (Directory.Exists(RutaNombre))
            {
                Directory.Delete(RutaNombre);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Directorio_DeleteAll(String RutaNombre)
        {
            if (Directory.Exists(RutaNombre))
            {
                Directory.Delete(RutaNombre, true);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Archivo_Existe(String RutaNombre)
        {
            Boolean ReturnValue = File.Exists(RutaNombre);
            return ReturnValue;
        }
        public Boolean Archivo_Eliminar(String RutaNombre)
        {
            if (Archivo_Existe(RutaNombre))
            {
                File.Delete(RutaNombre);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Archivo_Copiar(String RutaOrigen, String RutaDestino)
        {
            File.Copy(RutaOrigen, RutaDestino, true);
        }
        public Boolean ImagenMostrar(Image vImagen, String vFileServerMapPath, String vFileUbiNombre, String vFileNombreAlternativo)
        {
            Boolean vValoResultado = false;
            if (Archivo_Existe(vFileServerMapPath))
            {
                vImagen.ImageUrl = vFileUbiNombre;
                vValoResultado = true;
            }
            else
            {
                if (vFileNombreAlternativo != "")
                {
                    String vFileAlterServerMap = Path.GetDirectoryName(vFileServerMapPath) + "\\" + vFileNombreAlternativo;
                    if (Archivo_Existe(vFileAlterServerMap))
                    {
                        vImagen.ImageUrl = Path.GetDirectoryName(vFileUbiNombre) + "\\" + vFileNombreAlternativo;
                        vValoResultado = true;
                    }
                    else
                    {
                        vImagen.ImageUrl = "";
                    }
                }
            }
            return vValoResultado;
        }
        public String ImageneSinFoto()
        {
            return "..\\Imagenes\\SinFoto.gif";
        }
        public void SesionLimpiar(System.Web.SessionState.HttpSessionState sesion)
        {
            sesion.RemoveAll();
            sesion.Abandon();
        }
        public void SesionLimpiar(System.Web.SessionState.HttpSessionState sesion, String NomSessionEliminar)
        {
            sesion.Remove(NomSessionEliminar);
        }
        public void SesionLimpiarExcepcion(System.Web.SessionState.HttpSessionState sesion, String NomSessionExcepcion)
        {
            for (int i = sesion.Keys.Count - 1; i >= 0; i--)
            {
                String sKey = sesion.Keys[i].ToString();
                if (sKey != NomSessionExcepcion)
                {
                    sesion.RemoveAt(i);
                }
            }
        }
        public Boolean SesionEstado(Object sesion)
        {
            if (sesion == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public String FormatearMonto(Decimal MontoData)
        {
            //return MontoData.ToString("#,##0.00");
            return MontoData.ToString("n2");
        }
        public String FormatearMontoDolares(Decimal MontoData)
        {
            return "US$ " + MontoData.ToString("n2");
        }
        public String FormatearMontoSoles(Decimal MontoData)
        {
            return "S/. " + MontoData.ToString("n2");
        }
        public DateTime FechaSemanaDiaPrimero(DateTime Fecha)
        {
            DateTime vFechaResultado;
            Int32 NumDias = (Int32)Fecha.DayOfWeek;
            if (NumDias == 6 || NumDias == 0) //6=Sabado 0=Domingo
            {
                vFechaResultado = Fecha;
            }
            else
            {
                vFechaResultado = Fecha.AddDays(-(NumDias - 1));
            }
            return vFechaResultado;
        }
        public DateTime FechaSemanaDiaUltimo(DateTime Fecha)
        {
            DateTime vFechaResultado;
            Int32 NumDias = (Int32)Fecha.DayOfWeek;
            if (NumDias == 6 || NumDias == 0) //6=Sabado 0=Domingo
            {
                vFechaResultado = Fecha;
            }
            else
            {
                vFechaResultado = Fecha.AddDays((5 - NumDias));
            }
            return vFechaResultado;
        }
        public String MesNombre(Int32 NumMes)
        {
            String MesNombre = "";
            switch (NumMes)
            {
                case 1:
                    MesNombre = "Enero";
                    break;
                case 2:
                    MesNombre = "Febrero";
                    break;
                case 3:
                    MesNombre = "Marzo";
                    break;
                case 4:
                    MesNombre = "Abril";
                    break;
                case 5:
                    MesNombre = "Mayo";
                    break;
                case 6:
                    MesNombre = "Junio";
                    break;
                case 7:
                    MesNombre = "Julio";
                    break;
                case 8:
                    MesNombre = "Agosto";
                    break;
                case 9:
                    MesNombre = "Setiembre";
                    break;
                case 10:
                    MesNombre = "Octubre";
                    break;
                case 11:
                    MesNombre = "Noviembre";
                    break;
                case 12:
                    MesNombre = "Diciembre";
                    break;
            }
            return MesNombre;
        }
        public String ReemplaCarEspeciales(String DatoReemplazar)
        {
            String CarEspecial = "ÑÁÉÍÓÚñáéíóúÀÈÌÒÙàèìòùû";
            String CarEspecialRem = "NAEIOUnaeiouAEIOUaeiouu";
            for (Int32 Num = 0; Num < CarEspecial.Length; Num++)
            {
                DatoReemplazar = DatoReemplazar.Replace(CarEspecial.Substring(Num, 1), CarEspecialRem.Substring(Num, 1));
            }
            return DatoReemplazar;
        }
        public String ConverByteToKBMBGBTBPBEB(Decimal ArchivoTamano)
        {
            if (ArchivoTamano == 0)
            {
                return "";
            }
            Boolean BucleEstado = true;
            Decimal ResultValor = ArchivoTamano;
            String ResultDesc = "";
            Int32 PesoConteo = 0;
            String PesoDesc = "";
            //
            while (BucleEstado)
            {
                PesoConteo += 1;
                ResultValor = Math.Round((ResultValor / 1024), 2);
                //Math.Floor=Extrae la Parte Entera
                if (ResultValor > 0)
                {
                    if (PesoConteo == 1)
                    {
                        PesoDesc = "KB";
                    }
                    else if (PesoConteo == 2)
                    {
                        PesoDesc = "MB";
                    }
                    else if (PesoConteo == 3)
                    {
                        PesoDesc = "GB";
                    }
                    else if (PesoConteo == 4)
                    {
                        PesoDesc = "TB";
                    }
                    else if (PesoConteo == 5)
                    {
                        PesoDesc = "PB";
                    }
                    else if (PesoConteo == 6)
                    {
                        PesoDesc = "EB";
                    }
                    else if (PesoConteo == 7)
                    {
                        PesoDesc = "XX";
                    }
                    ResultDesc += ResultValor.ToString() + " " + PesoDesc + ", ";
                }
                else
                {
                    BucleEstado = false;
                }
            }
            return ResultDesc.Substring(0, ResultDesc.Length - 2);
        }
        public String ConverByteToValorMaximo(Decimal ArchivoTamano)
        {
            if (ArchivoTamano == 0)
            {
                return "";
            }
            Boolean BucleEstado = true;
            Decimal ResultValor = ArchivoTamano;
            Decimal ResultValorBackup = ArchivoTamano;
            String ResultDesc = "";
            Int32 PesoConteo = 0;
            String PesoDesc = "";
            //
            while (BucleEstado)
            {

                ResultValor = Math.Round((ResultValor / 1024), 2);
                //Math.Floor=Extrae la Parte Entera
                if (Math.Floor(ResultValor) > 0)
                {
                    ResultValorBackup = ResultValor;
                    PesoConteo += 1;
                }
                else
                {
                    BucleEstado = false;
                }
            }
            if (PesoConteo == 0)
            {
                PesoDesc = "Bytes";
            }
            else if (PesoConteo == 1)
            {
                PesoDesc = "KB";
            }
            else if (PesoConteo == 2)
            {
                PesoDesc = "MB";
            }
            else if (PesoConteo == 3)
            {
                PesoDesc = "GB";
            }
            else if (PesoConteo == 4)
            {
                PesoDesc = "TB";
            }
            else if (PesoConteo == 5)
            {
                PesoDesc = "PB";
            }
            else if (PesoConteo == 6)
            {
                PesoDesc = "EB";
            }
            else if (PesoConteo == 7)
            {
                PesoDesc = "XX";
            }
            ResultDesc = ResultValorBackup.ToString() + " " + PesoDesc;
            return ResultDesc;
        }
        public void MensajeBox(Page Pagina, String MensajeTexto, eMensajeTipo MensajeTipo)
        {
            String KeyScript = "ScriptKeyMsgbox" + DateTime.Now.Millisecond.ToString();
            MensajeTexto = MensajeTexto.Replace("'", " ");
            Pagina.ClientScript.RegisterStartupScript(Pagina.GetType(), KeyScript, "MensajeSpamTipo('" + MensajeTexto + "', '" + MensajeTipo + "');", true);
            //MensajeBox(this, ex.Message, "1");
        }
        public void MensajeBox(UpdatePanel uPanel, String MensajeTexto, eMensajeTipo MensajeTipo)
        {
            String KeyScript = "ScriptKeyMsgbox" + DateTime.Now.Millisecond.ToString();
            MensajeTexto = MensajeTexto.Replace("'", " ");
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "ScriptKey", "MensajeSpamTipo('" + MensajeTexto + "','" + MensajeTipo.ToString() + "');", true);
            //MensajeBox(udpPDivGrabar, ex.Message.ToString(), "1");
        }
        public void ScriptServidor(Page Pagina,String Script,Boolean UPanelJSWebForms)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            String KeyScript = "ScriptKeySer" + rand.Next().ToString();
            if (UPanelJSWebForms)
            {
                //Usando Codigo JavaScript siempre y cuando el control esta dentro de un UpdatePanel y el JavaScript afecte al WebForms
                ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType(), KeyScript, Script, true);
            }
            else
            {
                //Usando Codigo JavaScript siempre en cualquier parte de una ventana
                //this.ClientScript.RegisterStartupScript(this.GetType(), "ScriptKeyUpdate", "EmpresaTipoDiv('" + ddlCod_Etipo.SelectedValue + "');", true);
                Pagina.ClientScript.RegisterStartupScript(Pagina.GetType(), KeyScript, Script, true);
            }
        }
        public void ScriptServidor(UpdatePanel uPanel, String Script)
        {
            String KeyScript = "ScriptKeySer" + DateTime.Now.ToLongTimeString();
            //Este método se usa para registrar un bloque de script de inicio que se incluye cada vez que se produce una devolución de datos asincrónica.
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), KeyScript, Script, true);
            
        }
        public Boolean VerificaNavegadorMobil(System.Web.UI.Page page)
        {
            string u = page.Request.ServerVariables["HTTP_USER_AGENT"];
            Regex b = new Regex(@"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|meego.+mobile|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
            {
                return true; //Mobil
            }
            else
            {
                return false; //No Mobil
            }
        }
    }
}

