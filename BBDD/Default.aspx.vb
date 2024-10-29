
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient


Partial Class [Default]
    Inherits System.Web.UI.Page

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles form1.Load

        'Dim con As New SqlConnection(CWebGlobal.CadenaDeConexion)
        'con.Open()

        'Dim comando As New SqlCommand("Select * from Es_jugadores Where idJugador < 20", con)
        'Dim reader As SqlDataReader = comando.ExecuteReader

        ''If reader.HasRows Then

        ''    Label1.Text = "Tiene Filas"

        ''    Do While reader.Read()
        ''        Dim etiqueta As New Label
        ''        etiqueta.Text = reader("apodo")
        ''        Panel1.Controls.Add(etiqueta)

        ''        Dim saltoDeLinea As New LiteralControl
        ''        saltoDeLinea.Text = "<br />"
        ''        Panel1.Controls.Add(saltoDeLinea)
        ''    Loop
        ''Else
        ''    Label1.Text = "No tiene filas"

        ''End If

        'con.Close()

        'Dim jug1 As New CJugador("2", "Ronaldo")
        'jug1.idJugador = 2
        'jug1.apodo = "Rafinha"
        'jug1.grabate()

        'Dim jug2 As New CJugador
        'jug1.idJugador = 0
        'jug1.apodo = "Messi"
        'jug1.grabate()

        'Caso de uso del metodo Recupera
        Dim listaJugadores As List(Of CJugador)
        listaJugadores = CJugador.Recupera()
        For Each jugador As CJugador In listaJugadores
            'Asignado variables a las etiquetas
            Dim lblId As New Label
            lblId.Text = jugador.idJugador
            Dim lblApodo As New Label
            lblApodo.Text = jugador.apodo
            Dim lblNombre As New Label
            lblNombre.Text = jugador.nombre
            Dim lblApellidos As New Label
            lblApellidos.Text = jugador.apellidos

            'Saltos y espacio
            Dim saltoDeLinea As New LiteralControl
            Dim espacio As New LiteralControl
            Dim espacio2 As New LiteralControl
            espacio.Text = "&nbsp"
            espacio2.Text = "&nbsp"
            saltoDeLinea.Text = "<br />"

            'Añadiendo datos al panel
            Panel2.Controls.Add(lblId)
            Panel2.Controls.Add(espacio2)

            Panel2.Controls.Add(lblApodo)
            Panel2.Controls.Add(espacio)
            Panel2.Controls.Add(lblNombre)
            Panel2.Controls.Add(lblApellidos)

            Panel2.Controls.Add(espacio)
            'Salto de linea
            Panel2.Controls.Add(saltoDeLinea)
        Next

        '''''DATOS PARA PANEL 3

        Dim listaJugadores2 As List(Of CJugador)
        listaJugadores2 = CJugador.Recupera()
        For Each jugador As CJugador In listaJugadores2
            'Asignado variables a las etiquetas
            Dim lblId As New Label
            lblId.Text = jugador.idJugador
            Dim lblApodo As New Label
            lblApodo.Text = jugador.apodo
            Dim lblNombre As New Label
            lblNombre.Text = jugador.nombre
            Dim lblApellidos As New Label
            lblApellidos.Text = jugador.apellidos

            'Saltos y espacio
            Dim saltoDeLinea As New LiteralControl
            Dim espacio As New LiteralControl
            Dim espacio2 As New LiteralControl
            espacio.Text = "&nbsp"
            espacio2.Text = "&nbsp"
            saltoDeLinea.Text = "<br />"

            'Añadiendo datos al panel
            Panel3.Controls.Add(lblId)
            Panel3.Controls.Add(espacio2)

            Panel3.Controls.Add(lblApodo)
            Panel3.Controls.Add(espacio)
            Panel3.Controls.Add(lblNombre)
            Panel3.Controls.Add(lblApellidos)

            Panel3.Controls.Add(espacio)
            'Salto de linea
            Panel3.Controls.Add(saltoDeLinea)
        Next

        'añadiendo comentario para probar github

    End Sub
End Class

Public Class CWebGlobal
    Public Shared ReadOnly Property CadenaDeConexion As String
        Get
            Return ConfigurationManager.AppSettings("WCadenaConexion")

        End Get

    End Property
End Class

Public Class CJugador
    Public Sub New(idJugador As Integer, apodo As String, nombre As String, apellidos As String)
        Me.idJugador = idJugador
        Me.apodo = apodo
        Me.nombre = nombre
        Me.apellidos = apellidos

    End Sub

    Public Property idJugador As Integer
    Public Property apodo As String
    Public Property nombre As String
    Public Property apellidos As String

    Public Sub grabate()
        Dim con As New SqlConnection(CWebGlobal.CadenaDeConexion)
        con.Open()

        Dim CadenaSqul As String
        If idJugador > 0 Then
            CadenaSqul = "Update Es_Jugadores SET  apodo = @apodo Where idJugador = @idJugador"
        Else
            CadenaSqul = "Insert into Es_Jugadores (apodo) VALUES (@apodo)"

        End If

        Dim comando As New SqlCommand(CadenaSqul, con)

        comando.Parameters.AddWithValue("@apodo", apodo)
        If idJugador > 0 Then
            comando.Parameters.AddWithValue("@Idjugador", idJugador)
        End If
        comando.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Shared Function Recupera() As List(Of CJugador)

        Dim con As New SqlConnection(CWebGlobal.CadenaDeConexion)
        con.Open()
        Dim comando As New SqlCommand("Select * from Es_jugadores Where idJugador < 40", con)
        Dim reader As SqlDataReader = comando.ExecuteReader
        Dim jugadores As New List(Of CJugador)

        'Añadiendo los jugadores localizados a la lista "jugadores"
        Do While reader.Read
            jugadores.Add(New CJugador(reader("idJugador"), reader("apodo"), reader("nombre"), reader("apellidos")))
        Loop

        'Cerrando SqlDataREader y  la conexión.
        reader.Close()
        con.Close()
        Return jugadores

    End Function


End Class