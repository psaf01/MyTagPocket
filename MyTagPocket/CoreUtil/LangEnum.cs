using MyTagPocket.CoreUtil;
using static MyTagPocket.CoreUtil.LangEnum;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Language code
  /// </summary>
  public sealed class LangEnum : EnumBase<LangEnum, string, Lang, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of data</param>
    /// <param name="valueEnum">Device type</param>
    /// <param name="codeLang">Code language ISO</param>
    private LangEnum(string name, Lang valueEnum, string codeLang) : base(name, valueEnum, codeLang)
    {
    }

    /// <summary>
    /// Data type
    /// </summary>
    public enum Lang
    {
      /// <summary>
      /// Afar
      /// </summary>
      aa = 1,

      /// <summary>
      /// Afrikaans
      /// </summary>
      af = 2,

      /// <summary>
      /// Aghem
      /// </summary>
      agq = 3,

      /// <summary>
      /// Akan
      /// </summary>
      ak = 4,

      /// <summary>
      /// Amharic
      /// </summary>
      am = 5,

      /// <summary>
      /// Arabic
      /// </summary>
      ar = 6,

      /// <summary>
      /// Mapudungun
      /// </summary>
      arn = 7,

      /// <summary>
      /// Assamese - as
      /// </summary>
      ass = 8,

      /// <summary>
      /// Asu
      /// </summary>
      asa = 9,

      /// <summary>
      /// Asturian
      /// </summary>
      ast = 10,

      /// <summary>
      /// Azerbaijani
      /// </summary>
      az = 11,

      /// <summary>
      /// Bashkir
      /// </summary>
      ba = 12,

      /// <summary>
      /// Basaa
      /// </summary>
      bas = 13,

      /// <summary>
      /// Belarusian
      /// </summary>
      be = 14,

      /// <summary>
      /// Bemba
      /// </summary>
      bem = 15,

      /// <summary>
      /// Bena
      /// </summary>
      bez = 16,

      /// <summary>
      /// Bulgarian
      /// </summary>
      bg = 17,

      /// <summary>
      /// Edo
      /// </summary>
      bin = 18,

      /// <summary>
      /// Bamanankan
      /// </summary>
      bm = 19,

      /// <summary>
      /// Bangla
      /// </summary>
      bn = 20,

      /// <summary>
      /// Tibetan
      /// </summary>
      bo = 21,

      /// <summary>
      /// Breton
      /// </summary>
      br = 22,

      /// <summary>
      /// Bodo
      /// </summary>
      brx = 23,

      /// <summary>
      /// Bosnian
      /// </summary>
      bs = 24,

      /// <summary>
      /// Blin
      /// </summary>
      byn = 25,

      /// <summary>
      /// Catalan
      /// </summary>
      ca = 26,

      /// <summary>
      /// Chechen
      /// </summary>
      ce = 27,

      /// <summary>
      /// Chiga
      /// </summary>
      cgg = 28,

      /// <summary>
      /// Cherokee
      /// </summary>
      chr = 29,

      /// <summary>
      /// Corsican
      /// </summary>
      co = 30,

      /// <summary>
      /// Czech
      /// </summary>
      cs = 31,

      /// <summary>
      /// Church Slavic
      /// </summary>
      cu = 32,

      /// <summary>
      /// Welsh
      /// </summary>
      cy = 33,

      /// <summary>
      /// Danish
      /// </summary>
      da = 34,

      /// <summary>
      /// Taita
      /// </summary>
      dav = 35,

      /// <summary>
      /// German
      /// </summary>
      de = 36,

      /// <summary>
      /// Zarma
      /// </summary>
      dje = 37,

      /// <summary>
      /// Lower Sorbian
      /// </summary>
      dsb = 38,

      /// <summary>
      /// Duala
      /// </summary>
      dua = 39,

      /// <summary>
      /// Divehi
      /// </summary>
      dv = 40,

      /// <summary>
      /// Jola-Fonyi
      /// </summary>
      dyo = 41,

      /// <summary>
      /// Dzongkha
      /// </summary>
      dz = 42,

      /// <summary>
      /// Embu
      /// </summary>
      ebu = 43,

      /// <summary>
      /// Ewe
      /// </summary>
      ee = 44,

      /// <summary>
      /// Greek
      /// </summary>
      el = 45,

      /// <summary>
      /// English
      /// </summary>
      en = 46,

      /// <summary>
      /// Esperanto
      /// </summary>
      eo = 47,

      /// <summary>
      /// Spanish
      /// </summary>
      es = 48,

      /// <summary>
      /// Estonian
      /// </summary>
      et = 49,

      /// <summary>
      /// Basque
      /// </summary>
      eu = 50,

      /// <summary>
      /// Ewondo
      /// </summary>
      ewo = 51,

      /// <summary>
      /// Persian
      /// </summary>
      fa = 52,

      /// <summary>
      /// Fulah
      /// </summary>
      ff = 53,

      /// <summary>
      /// Finnish
      /// </summary>
      fi = 54,

      /// <summary>
      /// Filipino
      /// </summary>
      fil = 55,

      /// <summary>
      /// Faroese
      /// </summary>
      fo = 56,

      /// <summary>
      /// French
      /// </summary>
      fr = 57,

      /// <summary>
      /// Friulian
      /// </summary>
      fur = 58,

      /// <summary>
      /// Western Frisian
      /// </summary>
      fy = 59,

      /// <summary>
      /// Irish
      /// </summary>
      ga = 60,

      /// <summary>
      /// Scottish Gaelic
      /// </summary>
      gd = 61,

      /// <summary>
      /// Galician
      /// </summary>
      gl = 62,

      /// <summary>
      /// Guarani
      /// </summary>
      gn = 63,

      /// <summary>
      /// Swiss German
      /// </summary>
      gsw = 64,

      /// <summary>
      /// Gujarati
      /// </summary>
      gu = 65,

      /// <summary>
      /// Gusii
      /// </summary>
      guz = 66,

      /// <summary>
      /// Manx
      /// </summary>
      gv = 67,

      /// <summary>
      /// Hausa
      /// </summary>
      ha = 68,

      /// <summary>
      /// Hawaiian
      /// </summary>
      haw = 69,

      /// <summary>
      /// Hebrew
      /// </summary>
      he = 70,

      /// <summary>
      /// Hindi
      /// </summary>
      hi = 71,

      /// <summary>
      /// Croatian
      /// </summary>
      hr = 72,

      /// <summary>
      /// Upper Sorbian
      /// </summary>
      hsb = 73,

      /// <summary>
      /// Hungarian
      /// </summary>
      hu = 74,

      /// <summary>
      /// Armenian
      /// </summary>
      hy = 75,

      /// <summary>
      /// Interlingua
      /// </summary>
      ia = 76,

      /// <summary>
      /// Ibibio
      /// </summary>
      ibb = 77,

      /// <summary>
      /// Indonesian
      /// </summary>
      id = 78,

      /// <summary>
      /// Igbo
      /// </summary>
      ig = 79,

      /// <summary>
      /// Yi
      /// </summary>
      ii = 80,

      /// <summary>
      /// Icelandic - is
      /// </summary>
      iss = 81,

      /// <summary>
      /// Italian
      /// </summary>
      it = 82,

      /// <summary>
      /// Inuktitut
      /// </summary>
      iu = 83,

      /// <summary>
      /// Invariant Language (Invariant Country)
      /// </summary>
      iv = 84,

      /// <summary>
      /// Japanese
      /// </summary>
      ja = 85,

      /// <summary>
      /// Ngomba
      /// </summary>
      jgo = 86,

      /// <summary>
      /// Machame
      /// </summary>
      jmc = 87,

      /// <summary>
      /// Javanese
      /// </summary>
      jv = 88,

      /// <summary>
      /// Georgian
      /// </summary>
      ka = 89,

      /// <summary>
      /// Kabyle
      /// </summary>
      kab = 90,

      /// <summary>
      /// Kamba
      /// </summary>
      kam = 91,

      /// <summary>
      /// Makonde
      /// </summary>
      kde = 92,

      /// <summary>
      /// Kabuverdianu
      /// </summary>
      kea = 93,

      /// <summary>
      /// Koyra Chiini
      /// </summary>
      khq = 94,

      /// <summary>
      /// Kikuyu
      /// </summary>
      ki = 95,

      /// <summary>
      /// Kazakh
      /// </summary>
      kk = 96,

      /// <summary>
      /// Kako
      /// </summary>
      kkj = 97,

      /// <summary>
      /// Greenlandic
      /// </summary>
      kl = 98,

      /// <summary>
      /// Kalenjin
      /// </summary>
      kln = 99,

      /// <summary>
      /// Khmer
      /// </summary>
      km = 100,

      /// <summary>
      /// Kannada
      /// </summary>
      kn = 101,

      /// <summary>
      /// Korean
      /// </summary>
      ko = 102,

      /// <summary>
      /// Konkani
      /// </summary>
      kok = 103,

      /// <summary>
      /// Kanuri
      /// </summary>
      kr = 104,

      /// <summary>
      /// Kashmiri
      /// </summary>
      ks = 105,

      /// <summary>
      /// Shambala
      /// </summary>
      ksb = 106,

      /// <summary>
      /// Bafia
      /// </summary>
      ksf = 107,

      /// <summary>
      /// Colognian
      /// </summary>
      ksh = 108,

      /// <summary>
      /// Central Kurdish
      /// </summary>
      ku = 109,

      /// <summary>
      /// Cornish
      /// </summary>
      kw = 110,

      /// <summary>
      /// Kyrgyz
      /// </summary>
      ky = 111,

      /// <summary>
      /// Latin
      /// </summary>
      la = 112,

      /// <summary>
      /// Langi
      /// </summary>
      lag = 113,

      /// <summary>
      /// Luxembourgish
      /// </summary>
      lb = 114,

      /// <summary>
      /// Ganda
      /// </summary>
      lg = 115,

      /// <summary>
      /// Lakota
      /// </summary>
      lkt = 116,

      /// <summary>
      /// Lingala
      /// </summary>
      ln = 117,

      /// <summary>
      /// Lao
      /// </summary>
      lo = 118,

      /// <summary>
      /// Northern Luri
      /// </summary>
      lrc = 119,

      /// <summary>
      /// Lithuanian
      /// </summary>
      lt = 120,

      /// <summary>
      /// Luba-Katanga
      /// </summary>
      lu = 121,

      /// <summary>
      /// Luo
      /// </summary>
      luo = 122,

      /// <summary>
      /// Luyia
      /// </summary>
      luy = 123,

      /// <summary>
      /// Latvian
      /// </summary>
      lv = 124,

      /// <summary>
      /// Masai
      /// </summary>
      mas = 125,

      /// <summary>
      /// Meru
      /// </summary>
      mer = 126,

      /// <summary>
      /// Morisyen
      /// </summary>
      mfe = 127,

      /// <summary>
      /// Malagasy
      /// </summary>
      mg = 128,

      /// <summary>
      /// Makhuwa-Meetto
      /// </summary>
      mgh = 129,

      /// <summary>
      /// Metaʼ
      /// </summary>
      mgo = 130,

      /// <summary>
      /// Maori
      /// </summary>
      mi = 131,

      /// <summary>
      /// Macedonian
      /// </summary>
      mk = 132,

      /// <summary>
      /// Malayalam
      /// </summary>
      ml = 133,

      /// <summary>
      /// Mongolian
      /// </summary>
      mn = 134,

      /// <summary>
      /// Manipuri
      /// </summary>
      mni = 135,

      /// <summary>
      /// Mohawk
      /// </summary>
      moh = 136,

      /// <summary>
      /// Marathi
      /// </summary>
      mr = 137,

      /// <summary>
      /// Malay
      /// </summary>
      ms = 138,

      /// <summary>
      /// Maltese
      /// </summary>
      mt = 139,

      /// <summary>
      /// Mundang
      /// </summary>
      mua = 140,

      /// <summary>
      /// Burmese
      /// </summary>
      my = 141,

      /// <summary>
      /// Mazanderani
      /// </summary>
      mzn = 142,

      /// <summary>
      /// Nama
      /// </summary>
      naq = 143,

      /// <summary>
      /// Norwegian Bokmål
      /// </summary>
      nb = 144,

      /// <summary>
      /// North Ndebele
      /// </summary>
      nd = 145,

      /// <summary>
      /// Low German
      /// </summary>
      nds = 146,

      /// <summary>
      /// Nepali
      /// </summary>
      ne = 147,

      /// <summary>
      /// Dutch
      /// </summary>
      nl = 148,

      /// <summary>
      /// Kwasio
      /// </summary>
      nmg = 149,

      /// <summary>
      /// Norwegian Nynorsk
      /// </summary>
      nn = 150,

      /// <summary>
      /// Ngiemboon
      /// </summary>
      nnh = 151,

      /// <summary>
      /// N'ko
      /// </summary>
      nqo = 152,

      /// <summary>
      /// South Ndebele
      /// </summary>
      nr = 153,

      /// <summary>
      /// Sesotho sa Leboa
      /// </summary>
      nso = 154,

      /// <summary>
      /// Nuer
      /// </summary>
      nus = 155,

      /// <summary>
      /// Nyankole
      /// </summary>
      nyn = 156,

      /// <summary>
      /// Occitan
      /// </summary>
      oc = 157,

      /// <summary>
      /// Oromo
      /// </summary>
      om = 158,

      /// <summary>
      /// Odia
      /// </summary>
      or = 159,

      /// <summary>
      /// Ossetic
      /// </summary>
      os = 160,

      /// <summary>
      /// Punjabi
      /// </summary>
      pa = 161,

      /// <summary>
      /// Papiamento
      /// </summary>
      pap = 162,

      /// <summary>
      /// Polish
      /// </summary>
      pl = 163,

      /// <summary>
      /// Prussian
      /// </summary>
      prg = 164,

      /// <summary>
      /// Dari
      /// </summary>
      prs = 165,

      /// <summary>
      /// Pashto
      /// </summary>
      ps = 166,

      /// <summary>
      /// Portuguese
      /// </summary>
      pt = 167,

      /// <summary>
      /// K'iche'
      /// </summary>
      quc = 168,

      /// <summary>
      /// Quechua
      /// </summary>
      quz = 169,

      /// <summary>
      /// Romansh
      /// </summary>
      rm = 170,

      /// <summary>
      /// Rundi
      /// </summary>
      rn = 171,

      /// <summary>
      /// Romanian
      /// </summary>
      ro = 172,

      /// <summary>
      /// Rombo
      /// </summary>
      rof = 173,

      /// <summary>
      /// Russian
      /// </summary>
      ru = 174,

      /// <summary>
      /// Kinyarwanda
      /// </summary>
      rw = 175,

      /// <summary>
      /// Rwa
      /// </summary>
      rwk = 176,

      /// <summary>
      /// Sanskrit
      /// </summary>
      sa = 177,

      /// <summary>
      /// Sakha
      /// </summary>
      sah = 178,

      /// <summary>
      /// Samburu
      /// </summary>
      saq = 179,

      /// <summary>
      /// Sangu
      /// </summary>
      sbp = 180,

      /// <summary>
      /// Sindhi
      /// </summary>
      sd = 181,

      /// <summary>
      /// Northern Sami
      /// </summary>
      se = 182,

      /// <summary>
      /// Sena
      /// </summary>
      seh = 183,

      /// <summary>
      /// Koyraboro Senni
      /// </summary>
      ses = 184,

      /// <summary>
      /// Sango
      /// </summary>
      sg = 185,

      /// <summary>
      /// Tachelhit
      /// </summary>
      shi = 186,

      /// <summary>
      /// Sinhala
      /// </summary>
      si = 187,

      /// <summary>
      /// Slovak
      /// </summary>
      sk = 188,

      /// <summary>
      /// Slovenian
      /// </summary>
      sl = 189,

      /// <summary>
      /// Sami (Southern)
      /// </summary>
      sma = 190,

      /// <summary>
      /// Sami (Lule)
      /// </summary>
      smj = 191,

      /// <summary>
      /// Sami (Inari)
      /// </summary>
      smn = 192,

      /// <summary>
      /// Sami (Skolt)
      /// </summary>
      sms = 193,

      /// <summary>
      /// Shona
      /// </summary>
      sn = 194,

      /// <summary>
      /// Somali
      /// </summary>
      so = 195,

      /// <summary>
      /// Albanian
      /// </summary>
      sq = 196,

      /// <summary>
      /// Serbian
      /// </summary>
      sr = 197,

      /// <summary>
      /// siSwati
      /// </summary>
      ss = 198,

      /// <summary>
      /// Saho
      /// </summary>
      ssy = 199,

      /// <summary>
      /// Sesotho
      /// </summary>
      st = 200,

      /// <summary>
      /// Swedish
      /// </summary>
      sv = 201,

      /// <summary>
      /// Kiswahili
      /// </summary>
      sw = 202,

      /// <summary>
      /// Syriac
      /// </summary>
      syr = 203,

      /// <summary>
      /// Tamil
      /// </summary>
      ta = 204,

      /// <summary>
      /// Telugu
      /// </summary>
      te = 205,

      /// <summary>
      /// Teso
      /// </summary>
      teo = 206,

      /// <summary>
      /// Tajik
      /// </summary>
      tg = 207,

      /// <summary>
      /// Thai
      /// </summary>
      th = 208,

      /// <summary>
      /// Tigrinya
      /// </summary>
      ti = 209,

      /// <summary>
      /// Tigre
      /// </summary>
      tig = 210,

      /// <summary>
      /// Turkmen
      /// </summary>
      tk = 211,

      /// <summary>
      /// Setswana
      /// </summary>
      tn = 212,

      /// <summary>
      /// Tongan
      /// </summary>
      to = 213,

      /// <summary>
      /// Turkish
      /// </summary>
      tr = 214,

      /// <summary>
      /// Tsonga
      /// </summary>
      ts = 215,

      /// <summary>
      /// Tatar
      /// </summary>
      tt = 216,

      /// <summary>
      /// Tasawaq
      /// </summary>
      twq = 217,

      /// <summary>
      /// Central Atlas Tamazight
      /// </summary>
      tzm = 218,

      /// <summary>
      /// Uyghur
      /// </summary>
      ug = 219,

      /// <summary>
      /// Ukrainian
      /// </summary>
      uk = 220,

      /// <summary>
      /// Urdu
      /// </summary>
      ur = 221,

      /// <summary>
      /// Uzbek
      /// </summary>
      uz = 222,

      /// <summary>
      /// Vai
      /// </summary>
      vai = 223,

      /// <summary>
      /// Venda
      /// </summary>
      ve = 224,

      /// <summary>
      /// Vietnamese
      /// </summary>
      vi = 225,

      /// <summary>
      /// Volapük
      /// </summary>
      vo = 226,

      /// <summary>
      /// Vunjo
      /// </summary>
      vun = 227,

      /// <summary>
      /// Walser
      /// </summary>
      wae = 228,

      /// <summary>
      /// Wolaytta
      /// </summary>
      wal = 229,

      /// <summary>
      /// Wolof
      /// </summary>
      wo = 230,

      /// <summary>
      /// isiXhosa
      /// </summary>
      xh = 231,

      /// <summary>
      /// Soga
      /// </summary>
      xog = 232,

      /// <summary>
      /// Yangben
      /// </summary>
      yav = 233,

      /// <summary>
      /// Yiddish
      /// </summary>
      yi = 234,

      /// <summary>
      /// Yoruba
      /// </summary>
      yo = 235,

      /// <summary>
      /// Standard Moroccan Tamazight
      /// </summary>
      zgh = 236,

      /// <summary>
      /// Chinese
      /// </summary>
      zh = 237,

      /// <summary>
      /// isiZulu
      /// </summary>
      zu = 238
    }

    #region Definition
    /// <summary>
    /// Afar
    /// </summary>
    public static readonly LangEnum Afar = new LangEnum("Afar", Lang.aa, "aa");

    /// <summary>
    /// Afrikaans
    /// </summary>
    public static readonly LangEnum Afrikaans = new LangEnum("Afrikaans", Lang.af, "af");

    /// <summary>
    /// Aghem
    /// </summary>
    public static readonly LangEnum Aghem = new LangEnum("Aghem", Lang.agq, "agq");

    /// <summary>
    /// Akan
    /// </summary>
    public static readonly LangEnum Akan = new LangEnum("Akan", Lang.ak, "ak");

    /// <summary>
    /// Amharic
    /// </summary>
    public static readonly LangEnum Amharic = new LangEnum("Amharic", Lang.am, "am");

    /// <summary>
    /// Arabic
    /// </summary>
    public static readonly LangEnum Arabic = new LangEnum("Arabic", Lang.ar, "ar");

    /// <summary>
    /// Mapudungun
    /// </summary>
    public static readonly LangEnum Mapudungun = new LangEnum("Mapudungun", Lang.arn, "arn");

    /// <summary>
    /// Assamese
    /// </summary>
    public static readonly LangEnum Assamese = new LangEnum("Assamese", Lang.ass, "as");

    /// <summary>
    /// Asu
    /// </summary>
    public static readonly LangEnum Asu = new LangEnum("Asu", Lang.asa, "asa");

    /// <summary>
    /// Asturian
    /// </summary>
    public static readonly LangEnum Asturian = new LangEnum("Asturian", Lang.ast, "ast");

    /// <summary>
    /// Azerbaijani
    /// </summary>
    public static readonly LangEnum Azerbaijani = new LangEnum("Azerbaijani", Lang.az, "az");

    /// <summary>
    /// Bashkir
    /// </summary>
    public static readonly LangEnum Bashkir = new LangEnum("Bashkir", Lang.ba, "ba");

    /// <summary>
    /// Basaa
    /// </summary>
    public static readonly LangEnum Basaa = new LangEnum("Basaa", Lang.bas, "bas");

    /// <summary>
    /// Belarusian
    /// </summary>
    public static readonly LangEnum Belarusian = new LangEnum("Belarusian", Lang.be, "be");

    /// <summary>
    /// Bemba
    /// </summary>
    public static readonly LangEnum Bemba = new LangEnum("Bemba", Lang.bem, "bem");

    /// <summary>
    /// Bena
    /// </summary>
    public static readonly LangEnum Bena = new LangEnum("Bena", Lang.bez, "bez");

    /// <summary>
    /// Bulgarian
    /// </summary>
    public static readonly LangEnum Bulgarian = new LangEnum("Bulgarian", Lang.bg, "bg");

    /// <summary>
    /// Edo
    /// </summary>
    public static readonly LangEnum Edo = new LangEnum("Edo", Lang.bin, "bin");

    /// <summary>
    /// Bamanankan
    /// </summary>
    public static readonly LangEnum Bamanankan = new LangEnum("Bamanankan", Lang.bm, "bm");

    /// <summary>
    /// Bangla
    /// </summary>
    public static readonly LangEnum Bangla = new LangEnum("Bangla", Lang.bn, "bn");

    /// <summary>
    /// Tibetan
    /// </summary>
    public static readonly LangEnum Tibetan = new LangEnum("Tibetan", Lang.bo, "bo");

    /// <summary>
    /// Breton
    /// </summary>
    public static readonly LangEnum Breton = new LangEnum("Breton", Lang.br, "br");

    /// <summary>
    /// Bodo
    /// </summary>
    public static readonly LangEnum Bodo = new LangEnum("Bodo", Lang.brx, "brx");

    /// <summary>
    /// Bosnian
    /// </summary>
    public static readonly LangEnum Bosnian = new LangEnum("Bosnian", Lang.bs, "bs");

    /// <summary>
    /// Blin
    /// </summary>
    public static readonly LangEnum Blin = new LangEnum("Blin", Lang.byn, "byn");

    /// <summary>
    /// Catalan
    /// </summary>
    public static readonly LangEnum Catalan = new LangEnum("Catalan", Lang.ca, "ca");

    /// <summary>
    /// Chechen
    /// </summary>
    public static readonly LangEnum Chechen = new LangEnum("Chechen", Lang.ce, "ce");

    /// <summary>
    /// Chiga
    /// </summary>
    public static readonly LangEnum Chiga = new LangEnum("Chiga", Lang.cgg, "cgg");

    /// <summary>
    /// Cherokee
    /// </summary>
    public static readonly LangEnum Cherokee = new LangEnum("Cherokee", Lang.chr, "chr");

    /// <summary>
    /// Corsican
    /// </summary>
    public static readonly LangEnum Corsican = new LangEnum("Corsican", Lang.co, "co");

    /// <summary>
    /// Czech
    /// </summary>
    public static readonly LangEnum Czech = new LangEnum("Czech", Lang.cs, "cs");

    /// <summary>
    /// Church Slavic
    /// </summary>
    public static readonly LangEnum ChurchSlavic = new LangEnum("ChurchSlavic", Lang.cu, "cu");

    /// <summary>
    /// Welsh
    /// </summary>
    public static readonly LangEnum Welsh = new LangEnum("Welsh", Lang.cy, "cy");

    /// <summary>
    /// Danish
    /// </summary>
    public static readonly LangEnum Danish = new LangEnum("Danish", Lang.da, "da");

    /// <summary>
    /// Taita
    /// </summary>
    public static readonly LangEnum Taita = new LangEnum("Taita", Lang.dav, "dav");

    /// <summary>
    /// German
    /// </summary>
    public static readonly LangEnum German = new LangEnum("German", Lang.de, "de");

    /// <summary>
    /// Zarma
    /// </summary>
    public static readonly LangEnum Zarma = new LangEnum("Zarma", Lang.dje, "dje");

    /// <summary>
    /// Lower Sorbian
    /// </summary>
    public static readonly LangEnum LowerSorbian = new LangEnum("LowerSorbian", Lang.dsb, "dsb");

    /// <summary>
    /// Duala
    /// </summary>
    public static readonly LangEnum Duala = new LangEnum("Duala", Lang.dua, "dua");

    /// <summary>
    /// Divehi
    /// </summary>
    public static readonly LangEnum Divehi = new LangEnum("Divehi", Lang.dv, "dv");

    /// <summary>
    /// Jola-Fonyi
    /// </summary>
    public static readonly LangEnum JolaFonyi = new LangEnum("JolaFonyi", Lang.dyo, "dyo");

    /// <summary>
    /// Dzongkha
    /// </summary>
    public static readonly LangEnum Dzongkha = new LangEnum("Dzongkha", Lang.dz, "dz");

    /// <summary>
    /// Embu
    /// </summary>
    public static readonly LangEnum Embu = new LangEnum("Embu", Lang.ebu, "ebu");

    /// <summary>
    /// Ewe
    /// </summary>
    public static readonly LangEnum Ewe = new LangEnum("Ewe", Lang.ee, "ee");

    /// <summary>
    /// Greek
    /// </summary>
    public static readonly LangEnum Greek = new LangEnum("Greek", Lang.el, "el");

    /// <summary>
    /// English
    /// </summary>
    public static readonly LangEnum English = new LangEnum("English", Lang.en, "en");

    /// <summary>
    /// Esperanto
    /// </summary>
    public static readonly LangEnum Esperanto = new LangEnum("Esperanto", Lang.eo, "eo");

    /// <summary>
    /// Spanish
    /// </summary>
    public static readonly LangEnum Spanish = new LangEnum("Spanish", Lang.es, "es");

    /// <summary>
    /// Estonian
    /// </summary>
    public static readonly LangEnum Estonian = new LangEnum("Estonian", Lang.et, "et");

    /// <summary>
    /// Basque
    /// </summary>
    public static readonly LangEnum Basque = new LangEnum("Basque", Lang.eu, "eu");

    /// <summary>
    /// Ewondo
    /// </summary>
    public static readonly LangEnum Ewondo = new LangEnum("Ewondo", Lang.ewo, "ewo");

    /// <summary>
    /// Persian
    /// </summary>
    public static readonly LangEnum Persian = new LangEnum("Persian", Lang.fa, "fa");

    /// <summary>
    /// Fulah
    /// </summary>
    public static readonly LangEnum Fulah = new LangEnum("Fulah", Lang.ff, "ff");

    /// <summary>
    /// Finnish
    /// </summary>
    public static readonly LangEnum Finnish = new LangEnum("Finnish", Lang.fi, "fi");

    /// <summary>
    /// Filipino
    /// </summary>
    public static readonly LangEnum Filipino = new LangEnum("Filipino", Lang.fil, "fil");

    /// <summary>
    /// Faroese
    /// </summary>
    public static readonly LangEnum Faroese = new LangEnum("Faroese", Lang.fo, "fo");

    /// <summary>
    /// French
    /// </summary>
    public static readonly LangEnum French = new LangEnum("French", Lang.fr, "fr");

    /// <summary>
    /// Friulian
    /// </summary>
    public static readonly LangEnum Friulian = new LangEnum("Friulian", Lang.fur, "fur");

    /// <summary>
    /// Western Frisian
    /// </summary>
    public static readonly LangEnum WesternFrisian = new LangEnum("WesternFrisian", Lang.fy, "fy");

    /// <summary>
    /// Irish
    /// </summary>
    public static readonly LangEnum Irish = new LangEnum("Irish", Lang.ga, "ga");

    /// <summary>
    /// Scottish Gaelic
    /// </summary>
    public static readonly LangEnum ScottishGaelic = new LangEnum("ScottishGaelic", Lang.gd, "gd");

    /// <summary>
    /// Galician
    /// </summary>
    public static readonly LangEnum Galician = new LangEnum("Galician", Lang.gl, "gl");

    /// <summary>
    /// Guarani
    /// </summary>
    public static readonly LangEnum Guarani = new LangEnum("Guarani", Lang.gn, "gn");

    /// <summary>
    /// Swiss German
    /// </summary>
    public static readonly LangEnum SwissGerman = new LangEnum("SwissGerman", Lang.gsw, "gsw");

    /// <summary>
    /// Gujarati
    /// </summary>
    public static readonly LangEnum Gujarati = new LangEnum("Gujarati", Lang.gu, "gu");

    /// <summary>
    /// Gusii
    /// </summary>
    public static readonly LangEnum Gusii = new LangEnum("Gusii", Lang.guz, "guz");

    /// <summary>
    /// Manx
    /// </summary>
    public static readonly LangEnum Manx = new LangEnum("Manx", Lang.gv, "gv");

    /// <summary>
    /// Hausa
    /// </summary>
    public static readonly LangEnum Hausa = new LangEnum("Hausa", Lang.ha, "ha");

    /// <summary>
    /// Hawaiian
    /// </summary>
    public static readonly LangEnum Hawaiian = new LangEnum("Hawaiian", Lang.haw, "haw");

    /// <summary>
    /// Hebrew
    /// </summary>
    public static readonly LangEnum Hebrew = new LangEnum("Hebrew", Lang.he, "he");

    /// <summary>
    /// Hindi
    /// </summary>
    public static readonly LangEnum Hindi = new LangEnum("Hindi", Lang.hi, "hi");

    /// <summary>
    /// Croatian
    /// </summary>
    public static readonly LangEnum Croatian = new LangEnum("Croatian", Lang.hr, "hr");

    /// <summary>
    /// Upper Sorbian
    /// </summary>
    public static readonly LangEnum UpperSorbian = new LangEnum("UpperSorbian", Lang.hsb, "hsb");

    /// <summary>
    /// Hungarian
    /// </summary>
    public static readonly LangEnum Hungarian = new LangEnum("Hungarian", Lang.hu, "hu");

    /// <summary>
    /// Armenian
    /// </summary>
    public static readonly LangEnum Armenian = new LangEnum("Armenian", Lang.hy, "hy");

    /// <summary>
    /// Interlingua
    /// </summary>
    public static readonly LangEnum Interlingua = new LangEnum("Interlingua", Lang.ia, "ia");

    /// <summary>
    /// Ibibio
    /// </summary>
    public static readonly LangEnum Ibibio = new LangEnum("Ibibio", Lang.ibb, "ibb");

    /// <summary>
    /// Indonesian
    /// </summary>
    public static readonly LangEnum Indonesian = new LangEnum("Indonesian", Lang.id, "id");

    /// <summary>
    /// Igbo
    /// </summary>
    public static readonly LangEnum Igbo = new LangEnum("Igbo", Lang.ig, "ig");

    /// <summary>
    /// Yi
    /// </summary>
    public static readonly LangEnum Yi = new LangEnum("Yi", Lang.ii, "ii");

    /// <summary>
    /// Icelandic
    /// </summary>
    public static readonly LangEnum Icelandic = new LangEnum("Icelandic", Lang.iss, "is");

    /// <summary>
    /// Italian
    /// </summary>
    public static readonly LangEnum Italian = new LangEnum("Italian", Lang.it, "it");

    /// <summary>
    /// Inuktitut
    /// </summary>
    public static readonly LangEnum Inuktitut = new LangEnum("Inuktitut", Lang.iu, "iu");

    /// <summary>
    /// Invariant Language (Invariant Country)
    /// </summary>
    public static readonly LangEnum InvariantCountry = new LangEnum("InvariantCountry", Lang.iv, "iv");

    /// <summary>
    /// Japanese
    /// </summary>
    public static readonly LangEnum Japanese = new LangEnum("Japanese", Lang.ja, "ja");

    /// <summary>
    /// Ngomba
    /// </summary>
    public static readonly LangEnum Ngomba = new LangEnum("Ngomba", Lang.jgo, "jgo");

    /// <summary>
    /// Machame
    /// </summary>
    public static readonly LangEnum Machame = new LangEnum("Machame", Lang.jmc, "jmc");

    /// <summary>
    /// Javanese
    /// </summary>
    public static readonly LangEnum Javanese = new LangEnum("Javanese", Lang.jv, "jv");

    /// <summary>
    /// Georgian
    /// </summary>
    public static readonly LangEnum Georgian = new LangEnum("Georgian", Lang.ka, "ka");

    /// <summary>
    /// Kabyle
    /// </summary>
    public static readonly LangEnum Kabyle = new LangEnum("Kabyle", Lang.kab, "kab");

    /// <summary>
    /// Kamba
    /// </summary>
    public static readonly LangEnum Kamba = new LangEnum("Kamba", Lang.kam, "kam");

    /// <summary>
    /// Makonde
    /// </summary>
    public static readonly LangEnum Makonde = new LangEnum("Makonde", Lang.kde, "kde");

    /// <summary>
    /// Kabuverdianu
    /// </summary>
    public static readonly LangEnum Kabuverdianu = new LangEnum("Kabuverdianu", Lang.kea, "kea");

    /// <summary>
    /// Koyra Chiini
    /// </summary>
    public static readonly LangEnum KoyraChiini = new LangEnum("KoyraChiini", Lang.khq, "khq");

    /// <summary>
    /// Kikuyu
    /// </summary>
    public static readonly LangEnum Kikuyu = new LangEnum("Kikuyu", Lang.ki, "ki");

    /// <summary>
    /// Kazakh
    /// </summary>
    public static readonly LangEnum Kazakh = new LangEnum("Kazakh", Lang.kk, "kk");

    /// <summary>
    /// Kako
    /// </summary>
    public static readonly LangEnum Kako = new LangEnum("Kako", Lang.kkj, "kkj");

    /// <summary>
    /// Greenlandic
    /// </summary>
    public static readonly LangEnum Greenlandic = new LangEnum("Greenlandic", Lang.kl, "kl");

    /// <summary>
    /// Kalenjin
    /// </summary>
    public static readonly LangEnum Kalenjin = new LangEnum("Kalenjin", Lang.kln, "kln");

    /// <summary>
    /// Khmer
    /// </summary>
    public static readonly LangEnum Khmer = new LangEnum("Khmer", Lang.km, "km");

    /// <summary>
    /// Kannada
    /// </summary>
    public static readonly LangEnum Kannada = new LangEnum("Kannada", Lang.kn, "kn");

    /// <summary>
    /// Korean
    /// </summary>
    public static readonly LangEnum Korean = new LangEnum("Korean", Lang.ko, "ko");

    /// <summary>
    /// Konkani
    /// </summary>
    public static readonly LangEnum Konkani = new LangEnum("Konkani", Lang.kok, "kok");

    /// <summary>
    /// Kanuri
    /// </summary>
    public static readonly LangEnum Kanuri = new LangEnum("Kanuri", Lang.kr, "kr");

    /// <summary>
    /// Kashmiri
    /// </summary>
    public static readonly LangEnum Kashmiri = new LangEnum("Kashmiri", Lang.ks, "ks");

    /// <summary>
    /// Shambala
    /// </summary>
    public static readonly LangEnum Shambala = new LangEnum("Shambala", Lang.ksb, "ksb");

    /// <summary>
    /// Bafia
    /// </summary>
    public static readonly LangEnum Bafia = new LangEnum("Bafia", Lang.ksf, "ksf");

    /// <summary>
    /// Colognian
    /// </summary>
    public static readonly LangEnum Colognian = new LangEnum("Colognian", Lang.ksh, "ksh");

    /// <summary>
    /// Central Kurdish
    /// </summary>
    public static readonly LangEnum CentralKurdish = new LangEnum("CentralKurdish", Lang.ku, "ku");

    /// <summary>
    /// Cornish
    /// </summary>
    public static readonly LangEnum Cornish = new LangEnum("Cornish", Lang.kw, "kw");

    /// <summary>
    /// Kyrgyz
    /// </summary>
    public static readonly LangEnum Kyrgyz = new LangEnum("Kyrgyz", Lang.ky, "ky");

    /// <summary>
    /// Latin
    /// </summary>
    public static readonly LangEnum Latin = new LangEnum("Latin", Lang.la, "la");

    /// <summary>
    /// Langi
    /// </summary>
    public static readonly LangEnum Langi = new LangEnum("Langi", Lang.lag, "lag");

    /// <summary>
    /// Luxembourgish
    /// </summary>
    public static readonly LangEnum Luxembourgish = new LangEnum("Luxembourgish", Lang.lb, "lb");

    /// <summary>
    /// Ganda
    /// </summary>
    public static readonly LangEnum Ganda = new LangEnum("Ganda", Lang.lg, "lg");

    /// <summary>
    /// Lakota
    /// </summary>
    public static readonly LangEnum Lakota = new LangEnum("Lakota", Lang.lkt, "lkt");

    /// <summary>
    /// Lingala
    /// </summary>
    public static readonly LangEnum Lingala = new LangEnum("Lingala", Lang.ln, "ln");

    /// <summary>
    /// Lao
    /// </summary>
    public static readonly LangEnum Lao = new LangEnum("Lao", Lang.lo, "lo");

    /// <summary>
    /// Northern Luri
    /// </summary>
    public static readonly LangEnum NorthernLuri = new LangEnum("NorthernLuri", Lang.lrc, "lrc");

    /// <summary>
    /// Lithuanian
    /// </summary>
    public static readonly LangEnum Lithuanian = new LangEnum("Lithuanian", Lang.lt, "lt");

    /// <summary>
    /// Luba-Katanga
    /// </summary>
    public static readonly LangEnum LubaKatanga = new LangEnum("LubaKatanga", Lang.lu, "lu");

    /// <summary>
    /// Luo
    /// </summary>
    public static readonly LangEnum Luo = new LangEnum("Luo", Lang.luo, "luo");

    /// <summary>
    /// Luyia
    /// </summary>
    public static readonly LangEnum Luyia = new LangEnum("Luyia", Lang.luy, "luy");

    /// <summary>
    /// Latvian
    /// </summary>
    public static readonly LangEnum Latvian = new LangEnum("Latvian", Lang.lv, "lv");

    /// <summary>
    /// Masai
    /// </summary>
    public static readonly LangEnum Masai = new LangEnum("Masai", Lang.mas, "mas");

    /// <summary>
    /// Meru
    /// </summary>
    public static readonly LangEnum Meru = new LangEnum("Meru", Lang.mer, "mer");

    /// <summary>
    /// Morisyen
    /// </summary>
    public static readonly LangEnum Morisyen = new LangEnum("Morisyen", Lang.mfe, "mfe");

    /// <summary>
    /// Malagasy
    /// </summary>
    public static readonly LangEnum Malagasy = new LangEnum("Malagasy", Lang.mg, "mg");

    /// <summary>
    /// Makhuwa-Meetto
    /// </summary>
    public static readonly LangEnum MakhuwaMeetto = new LangEnum("MakhuwaMeetto", Lang.mgh, "mgh");

    /// <summary>
    /// Metaʼ
    /// </summary>
    public static readonly LangEnum Metaʼ = new LangEnum("Metaʼ", Lang.mgo, "mgo");

    /// <summary>
    /// Maori
    /// </summary>
    public static readonly LangEnum Maori = new LangEnum("Maori", Lang.mi, "mi");

    /// <summary>
    /// Macedonian
    /// </summary>
    public static readonly LangEnum Macedonian = new LangEnum("Macedonian", Lang.mk, "mk");

    /// <summary>
    /// Malayalam
    /// </summary>
    public static readonly LangEnum Malayalam = new LangEnum("Malayalam", Lang.ml, "ml");

    /// <summary>
    /// Mongolian
    /// </summary>
    public static readonly LangEnum Mongolian = new LangEnum("Mongolian", Lang.mn, "mn");

    /// <summary>
    /// Manipuri
    /// </summary>
    public static readonly LangEnum Manipuri = new LangEnum("Manipuri", Lang.mni, "mni");

    /// <summary>
    /// Mohawk
    /// </summary>
    public static readonly LangEnum Mohawk = new LangEnum("Mohawk", Lang.moh, "moh");

    /// <summary>
    /// Marathi
    /// </summary>
    public static readonly LangEnum Marathi = new LangEnum("Marathi", Lang.mr, "mr");

    /// <summary>
    /// Malay
    /// </summary>
    public static readonly LangEnum Malay = new LangEnum("Malay", Lang.ms, "ms");

    /// <summary>
    /// Maltese
    /// </summary>
    public static readonly LangEnum Maltese = new LangEnum("Maltese", Lang.mt, "mt");

    /// <summary>
    /// Mundang
    /// </summary>
    public static readonly LangEnum Mundang = new LangEnum("Mundang", Lang.mua, "mua");

    /// <summary>
    /// Burmese
    /// </summary>
    public static readonly LangEnum Burmese = new LangEnum("Burmese", Lang.my, "my");

    /// <summary>
    /// Mazanderani
    /// </summary>
    public static readonly LangEnum Mazanderani = new LangEnum("Mazanderani", Lang.mzn, "mzn");

    /// <summary>
    /// Nama
    /// </summary>
    public static readonly LangEnum Nama = new LangEnum("Nama", Lang.naq, "naq");

    /// <summary>
    /// Norwegian Bokmål
    /// </summary>
    public static readonly LangEnum NorwegianBokmål = new LangEnum("NorwegianBokmål", Lang.nb, "nb");

    /// <summary>
    /// North Ndebele
    /// </summary>
    public static readonly LangEnum NorthNdebele = new LangEnum("NorthNdebele", Lang.nd, "nd");

    /// <summary>
    /// Low German
    /// </summary>
    public static readonly LangEnum LowGerman = new LangEnum("LowGerman", Lang.nds, "nds");

    /// <summary>
    /// Nepali
    /// </summary>
    public static readonly LangEnum Nepali = new LangEnum("Nepali", Lang.ne, "ne");

    /// <summary>
    /// Dutch
    /// </summary>
    public static readonly LangEnum Dutch = new LangEnum("Dutch", Lang.nl, "nl");

    /// <summary>
    /// Kwasio
    /// </summary>
    public static readonly LangEnum Kwasio = new LangEnum("Kwasio", Lang.nmg, "nmg");

    /// <summary>
    /// Norwegian Nynorsk
    /// </summary>
    public static readonly LangEnum NorwegianNynorsk = new LangEnum("NorwegianNynorsk", Lang.nn, "nn");

    /// <summary>
    /// Ngiemboon
    /// </summary>
    public static readonly LangEnum Ngiemboon = new LangEnum("Ngiemboon", Lang.nnh, "nnh");

    /// <summary>
    /// N'ko
    /// </summary>
    public static readonly LangEnum Nko = new LangEnum("Nko", Lang.nqo, "nqo");

/// <summary>
/// South Ndebele
/// </summary>
public static readonly LangEnum SouthNdebele = new LangEnum("SouthNdebele", Lang.nr, "nr");

    /// <summary>
    /// Sesotho sa Leboa
    /// </summary>
    public static readonly LangEnum SesothosaLeboa = new LangEnum("SesothosaLeboa", Lang.nso, "nso");

    /// <summary>
    /// Nuer
    /// </summary>
    public static readonly LangEnum Nuer = new LangEnum("Nuer", Lang.nus, "nus");

    /// <summary>
    /// Nyankole
    /// </summary>
    public static readonly LangEnum Nyankole = new LangEnum("Nyankole", Lang.nyn, "nyn");

    /// <summary>
    /// Occitan
    /// </summary>
    public static readonly LangEnum Occitan = new LangEnum("Occitan", Lang.oc, "oc");

    /// <summary>
    /// Oromo
    /// </summary>
    public static readonly LangEnum Oromo = new LangEnum("Oromo", Lang.om, "om");

    /// <summary>
    /// Odia
    /// </summary>
    public static readonly LangEnum Odia = new LangEnum("Odia", Lang.or, "or");

    /// <summary>
    /// Ossetic
    /// </summary>
    public static readonly LangEnum Ossetic = new LangEnum("Ossetic", Lang.os, "os");

    /// <summary>
    /// Punjabi
    /// </summary>
    public static readonly LangEnum Punjabi = new LangEnum("Punjabi", Lang.pa, "pa");

    /// <summary>
    /// Papiamento
    /// </summary>
    public static readonly LangEnum Papiamento = new LangEnum("Papiamento", Lang.pap, "pap");

    /// <summary>
    /// Polish
    /// </summary>
    public static readonly LangEnum Polish = new LangEnum("Polish", Lang.pl, "pl");

    /// <summary>
    /// Prussian
    /// </summary>
    public static readonly LangEnum Prussian = new LangEnum("Prussian", Lang.prg, "prg");

    /// <summary>
    /// Dari
    /// </summary>
    public static readonly LangEnum Dari = new LangEnum("Dari", Lang.prs, "prs");

    /// <summary>
    /// Pashto
    /// </summary>
    public static readonly LangEnum Pashto = new LangEnum("Pashto", Lang.ps, "ps");

    /// <summary>
    /// Portuguese
    /// </summary>
    public static readonly LangEnum Portuguese = new LangEnum("Portuguese", Lang.pt, "pt");

    /// <summary>
    /// K'iche'
    /// </summary>
    public static readonly LangEnum Kiche = new LangEnum("Kiche", Lang.quc, "quc");

    /// <summary>
    /// Quechua
    /// </summary>
    public static readonly LangEnum Quechua = new LangEnum("Quechua", Lang.quz, "quz");

    /// <summary>
    /// Romansh
    /// </summary>
    public static readonly LangEnum Romansh = new LangEnum("Romansh", Lang.rm, "rm");

    /// <summary>
    /// Rundi
    /// </summary>
    public static readonly LangEnum Rundi = new LangEnum("Rundi", Lang.rn, "rn");

    /// <summary>
    /// Romanian
    /// </summary>
    public static readonly LangEnum Romanian = new LangEnum("Romanian", Lang.ro, "ro");

    /// <summary>
    /// Rombo
    /// </summary>
    public static readonly LangEnum Rombo = new LangEnum("Rombo", Lang.rof, "rof");

    /// <summary>
    /// Russian
    /// </summary>
    public static readonly LangEnum Russian = new LangEnum("Russian", Lang.ru, "ru");

    /// <summary>
    /// Kinyarwanda
    /// </summary>
    public static readonly LangEnum Kinyarwanda = new LangEnum("Kinyarwanda", Lang.rw, "rw");

    /// <summary>
    /// Rwa
    /// </summary>
    public static readonly LangEnum Rwa = new LangEnum("Rwa", Lang.rwk, "rwk");

    /// <summary>
    /// Sanskrit
    /// </summary>
    public static readonly LangEnum Sanskrit = new LangEnum("Sanskrit", Lang.sa, "sa");

    /// <summary>
    /// Sakha
    /// </summary>
    public static readonly LangEnum Sakha = new LangEnum("Sakha", Lang.sah, "sah");

    /// <summary>
    /// Samburu
    /// </summary>
    public static readonly LangEnum Samburu = new LangEnum("Samburu", Lang.saq, "saq");

    /// <summary>
    /// Sangu
    /// </summary>
    public static readonly LangEnum Sangu = new LangEnum("Sangu", Lang.sbp, "sbp");

    /// <summary>
    /// Sindhi
    /// </summary>
    public static readonly LangEnum Sindhi = new LangEnum("Sindhi", Lang.sd, "sd");

    /// <summary>
    /// Northern Sami
    /// </summary>
    public static readonly LangEnum NorthernSami = new LangEnum("NorthernSami", Lang.se, "se");

    /// <summary>
    /// Sena
    /// </summary>
    public static readonly LangEnum Sena = new LangEnum("Sena", Lang.seh, "seh");

    /// <summary>
    /// Koyraboro Senni
    /// </summary>
    public static readonly LangEnum KoyraboroSenni = new LangEnum("KoyraboroSenni", Lang.ses, "ses");

    /// <summary>
    /// Sango
    /// </summary>
    public static readonly LangEnum Sango = new LangEnum("Sango", Lang.sg, "sg");

    /// <summary>
    /// Tachelhit
    /// </summary>
    public static readonly LangEnum Tachelhit = new LangEnum("Tachelhit", Lang.shi, "shi");

    /// <summary>
    /// Sinhala
    /// </summary>
    public static readonly LangEnum Sinhala = new LangEnum("Sinhala", Lang.si, "si");

    /// <summary>
    /// Slovak
    /// </summary>
    public static readonly LangEnum Slovak = new LangEnum("Slovak", Lang.sk, "sk");

    /// <summary>
    /// Slovenian
    /// </summary>
    public static readonly LangEnum Slovenian = new LangEnum("Slovenian", Lang.sl, "sl");

    /// <summary>
    /// Sami (Southern)
    /// </summary>
    public static readonly LangEnum SamiSouthern = new LangEnum("SamiSouthern", Lang.sma, "sma");

    /// <summary>
    /// Sami (Lule)
    /// </summary>
    public static readonly LangEnum SamiLule = new LangEnum("SamiLule", Lang.smj, "smj");

    /// <summary>
    /// Sami (Inari)
    /// </summary>
    public static readonly LangEnum SamiInari = new LangEnum("SamiInari", Lang.smn, "smn");

    /// <summary>
    /// Sami (Skolt)
    /// </summary>
    public static readonly LangEnum SamiSkolt = new LangEnum("SamiSkolt", Lang.sms, "sms");

    /// <summary>
    /// Shona
    /// </summary>
    public static readonly LangEnum Shona = new LangEnum("Shona", Lang.sn, "sn");

    /// <summary>
    /// Somali
    /// </summary>
    public static readonly LangEnum Somali = new LangEnum("Somali", Lang.so, "so");

    /// <summary>
    /// Albanian
    /// </summary>
    public static readonly LangEnum Albanian = new LangEnum("Albanian", Lang.sq, "sq");

    /// <summary>
    /// Serbian
    /// </summary>
    public static readonly LangEnum Serbian = new LangEnum("Serbian", Lang.sr, "sr");

    /// <summary>
    /// siSwati
    /// </summary>
    public static readonly LangEnum siSwati = new LangEnum("siSwati", Lang.ss, "ss");

    /// <summary>
    /// Saho
    /// </summary>
    public static readonly LangEnum Saho = new LangEnum("Saho", Lang.ssy, "ssy");

    /// <summary>
    /// Sesotho
    /// </summary>
    public static readonly LangEnum Sesotho = new LangEnum("Sesotho", Lang.st, "st");

    /// <summary>
    /// Swedish
    /// </summary>
    public static readonly LangEnum Swedish = new LangEnum("Swedish", Lang.sv, "sv");

    /// <summary>
    /// Kiswahili
    /// </summary>
    public static readonly LangEnum Kiswahili = new LangEnum("Kiswahili", Lang.sw, "sw");

    /// <summary>
    /// Syriac
    /// </summary>
    public static readonly LangEnum Syriac = new LangEnum("Syriac", Lang.syr, "syr");

    /// <summary>
    /// Tamil
    /// </summary>
    public static readonly LangEnum Tamil = new LangEnum("Tamil", Lang.ta, "ta");

    /// <summary>
    /// Telugu
    /// </summary>
    public static readonly LangEnum Telugu = new LangEnum("Telugu", Lang.te, "te");

    /// <summary>
    /// Teso
    /// </summary>
    public static readonly LangEnum Teso = new LangEnum("Teso", Lang.teo, "teo");

    /// <summary>
    /// Tajik
    /// </summary>
    public static readonly LangEnum Tajik = new LangEnum("Tajik", Lang.tg, "tg");

    /// <summary>
    /// Thai
    /// </summary>
    public static readonly LangEnum Thai = new LangEnum("Thai", Lang.th, "th");

    /// <summary>
    /// Tigrinya
    /// </summary>
    public static readonly LangEnum Tigrinya = new LangEnum("Tigrinya", Lang.ti, "ti");

    /// <summary>
    /// Tigre
    /// </summary>
    public static readonly LangEnum Tigre = new LangEnum("Tigre", Lang.tig, "tig");

    /// <summary>
    /// Turkmen
    /// </summary>
    public static readonly LangEnum Turkmen = new LangEnum("Turkmen", Lang.tk, "tk");

    /// <summary>
    /// Setswana
    /// </summary>
    public static readonly LangEnum Setswana = new LangEnum("Setswana", Lang.tn, "tn");

    /// <summary>
    /// Tongan
    /// </summary>
    public static readonly LangEnum Tongan = new LangEnum("Tongan", Lang.to, "to");

    /// <summary>
    /// Turkish
    /// </summary>
    public static readonly LangEnum Turkish = new LangEnum("Turkish", Lang.tr, "tr");

    /// <summary>
    /// Tsonga
    /// </summary>
    public static readonly LangEnum Tsonga = new LangEnum("Tsonga", Lang.ts, "ts");

    /// <summary>
    /// Tatar
    /// </summary>
    public static readonly LangEnum Tatar = new LangEnum("Tatar", Lang.tt, "tt");

    /// <summary>
    /// Tasawaq
    /// </summary>
    public static readonly LangEnum Tasawaq = new LangEnum("Tasawaq", Lang.twq, "twq");

    /// <summary>
    /// Central Atlas Tamazight
    /// </summary>
    public static readonly LangEnum CentralAtlasTamazight = new LangEnum("CentralAtlasTamazight", Lang.tzm, "tzm");

    /// <summary>
    /// Uyghur
    /// </summary>
    public static readonly LangEnum Uyghur = new LangEnum("Uyghur", Lang.ug, "ug");

    /// <summary>
    /// Ukrainian
    /// </summary>
    public static readonly LangEnum Ukrainian = new LangEnum("Ukrainian", Lang.uk, "uk");

    /// <summary>
    /// Urdu
    /// </summary>
    public static readonly LangEnum Urdu = new LangEnum("Urdu", Lang.ur, "ur");

    /// <summary>
    /// Uzbek
    /// </summary>
    public static readonly LangEnum Uzbek = new LangEnum("Uzbek", Lang.uz, "uz");

    /// <summary>
    /// Vai
    /// </summary>
    public static readonly LangEnum Vai = new LangEnum("Vai", Lang.vai, "vai");

    /// <summary>
    /// Venda
    /// </summary>
    public static readonly LangEnum Venda = new LangEnum("Venda", Lang.ve, "ve");

    /// <summary>
    /// Vietnamese
    /// </summary>
    public static readonly LangEnum Vietnamese = new LangEnum("Vietnamese", Lang.vi, "vi");

    /// <summary>
    /// Volapük
    /// </summary>
    public static readonly LangEnum Volapük = new LangEnum("Volapük", Lang.vo, "vo");

    /// <summary>
    /// Vunjo
    /// </summary>
    public static readonly LangEnum Vunjo = new LangEnum("Vunjo", Lang.vun, "vun");

    /// <summary>
    /// Walser
    /// </summary>
    public static readonly LangEnum Walser = new LangEnum("Walser", Lang.wae, "wae");

    /// <summary>
    /// Wolaytta
    /// </summary>
    public static readonly LangEnum Wolaytta = new LangEnum("Wolaytta", Lang.wal, "wal");

    /// <summary>
    /// Wolof
    /// </summary>
    public static readonly LangEnum Wolof = new LangEnum("Wolof", Lang.wo, "wo");

    /// <summary>
    /// isiXhosa
    /// </summary>
    public static readonly LangEnum isiXhosa = new LangEnum("isiXhosa", Lang.xh, "xh");

    /// <summary>
    /// Soga
    /// </summary>
    public static readonly LangEnum Soga = new LangEnum("Soga", Lang.xog, "xog");

    /// <summary>
    /// Yangben
    /// </summary>
    public static readonly LangEnum Yangben = new LangEnum("Yangben", Lang.yav, "yav");

    /// <summary>
    /// Yiddish
    /// </summary>
    public static readonly LangEnum Yiddish = new LangEnum("Yiddish", Lang.yi, "yi");

    /// <summary>
    /// Yoruba
    /// </summary>
    public static readonly LangEnum Yoruba = new LangEnum("Yoruba", Lang.yo, "yo");

    /// <summary>
    /// Standard Moroccan Tamazight
    /// </summary>
    public static readonly LangEnum StandardMoroccanTamazight = new LangEnum("StandardMoroccanTamazight", Lang.zgh, "zgh");

    /// <summary>
    /// Chinese
    /// </summary>
    public static readonly LangEnum Chinese = new LangEnum("Chinese", Lang.zh, "zh");

    /// <summary>
    /// isiZulu
    /// </summary>
    public static readonly LangEnum isiZulu = new LangEnum("isiZulu", Lang.zu, "zu");
    #endregion Definition
  }
}
