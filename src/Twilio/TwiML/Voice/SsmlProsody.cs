/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML.Voice
{

  /// <summary>
  /// Controling Volume, Speaking Rate, and Pitch in Say
  /// </summary>
  public class SsmlProsody : TwiML
  {
    /// <summary>
    /// Words to speak
    /// </summary>
    public string Words { get; set; }
    /// <summary>
    /// Specify the volume, available values: default, silent, x-soft, soft, medium, loud, x-loud, +ndB, -ndB
    /// </summary>
    public string Volume { get; set; }
    /// <summary>
    /// Specify the rate, available values: x-slow, slow, medium, fast, x-fast, n%
    /// </summary>
    public string Rate { get; set; }
    /// <summary>
    /// Specify the pitch, available values: default, x-low, low, medium, high, x-high, +n%, -n%
    /// </summary>
    public string Pitch { get; set; }

    /// <summary>
    /// Create a new SsmlProsody
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="volume"> Specify the volume, available values: default, silent, x-soft, soft, medium, loud, x-loud,
    ///              +ndB, -ndB </param>
    /// <param name="rate"> Specify the rate, available values: x-slow, slow, medium, fast, x-fast, n% </param>
    /// <param name="pitch"> Specify the pitch, available values: default, x-low, low, medium, high, x-high, +n%, -n%
    ///             </param>
    public SsmlProsody(string words = null,
                       string volume = null,
                       string rate = null,
                       string pitch = null) : base("prosody")
    {
      this.Words = words;
      this.Volume = volume;
      this.Rate = rate;
      this.Pitch = pitch;
    }

    /// <summary>
    /// Return the body of the TwiML tag
    /// </summary>
    protected override string GetElementBody()
    {
      return this.Words != null ? this.Words : string.Empty;
    }

    /// <summary>
    /// Return the attributes of the TwiML tag
    /// </summary>
    protected override List<XAttribute> GetElementAttributes()
    {
      var attributes = new List<XAttribute>();
      if (this.Volume != null)
      {
        attributes.Add(new XAttribute("volume", this.Volume));
      }
      if (this.Rate != null)
      {
        attributes.Add(new XAttribute("rate", this.Rate));
      }
      if (this.Pitch != null)
      {
        attributes.Add(new XAttribute("pitch", this.Pitch));
      }
      return attributes;
    }

    /// <summary>
    /// Create a new <Break/> element and append it as a child of this element.
    /// </summary>
    /// <param name="strength"> Set a pause based on strength </param>
    /// <param name="time"> Set a pause to a specific length of time in seconds or milliseconds, available values:
    ///            [number]s, [number]ms </param>
    public SsmlProsody Break(SsmlBreak.StrengthEnum strength = null, string time = null)
    {
      var newChild = new SsmlBreak(strength, time);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <Break/> element as a child of this element
    /// </summary>
    /// <param name="ssmlBreak"> A SsmlBreak instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlBreak(SsmlBreak ssmlBreak)
    {
      this.Append(ssmlBreak);
      return this;
    }

    /// <summary>
    /// Create a new <Break/> element and append it as a child of this element.
    /// </summary>
    /// <param name="strength"> Set a pause based on strength </param>
    /// <param name="time"> Set a pause to a specific length of time in seconds or milliseconds, available values:
    ///            [number]s, [number]ms </param>
    [System.Obsolete("This method is deprecated, use .Break() instead.")]
    public SsmlProsody SsmlBreak(SsmlBreak.StrengthEnum strength = null, string time = null)
    {
      return Break(strength, time);
    }

    /// <summary>
    /// Create a new <Emphasis/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to emphasize, the body of the TwiML Element. </param>
    /// <param name="level"> Specify the degree of emphasis </param>
    public SsmlProsody Emphasis(string words = null, SsmlEmphasis.LevelEnum level = null)
    {
      var newChild = new SsmlEmphasis(words, level);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <Emphasis/> element as a child of this element
    /// </summary>
    /// <param name="ssmlEmphasis"> A SsmlEmphasis instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlEmphasis(SsmlEmphasis ssmlEmphasis)
    {
      this.Append(ssmlEmphasis);
      return this;
    }

    /// <summary>
    /// Create a new <Emphasis/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to emphasize, the body of the TwiML Element. </param>
    /// <param name="level"> Specify the degree of emphasis </param>
    [System.Obsolete("This method is deprecated, use .Emphasis() instead.")]
    public SsmlProsody SsmlEmphasis(string words = null, SsmlEmphasis.LevelEnum level = null)
    {
      return Emphasis(words, level);
    }

    /// <summary>
    /// Create a new <Lang/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="xml:Lang"> Specify the language </param>
    public SsmlProsody Lang(string words = null, SsmlLang.XmlLangEnum xmlLang = null)
    {
      var newChild = new SsmlLang(words, xmlLang);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <Lang/> element as a child of this element
    /// </summary>
    /// <param name="ssmlLang"> A SsmlLang instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlLang(SsmlLang ssmlLang)
    {
      this.Append(ssmlLang);
      return this;
    }

    /// <summary>
    /// Create a new <Lang/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="xml:Lang"> Specify the language </param>
    [System.Obsolete("This method is deprecated, use .Lang() instead.")]
    public SsmlProsody SsmlLang(string words = null, SsmlLang.XmlLangEnum xmlLang = null)
    {
      return Lang(words, xmlLang);
    }

    /// <summary>
    /// Create a new <P/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    public SsmlProsody P(string words = null)
    {
      var newChild = new SsmlP(words);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <P/> element as a child of this element
    /// </summary>
    /// <param name="ssmlP"> A SsmlP instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlP(SsmlP ssmlP)
    {
      this.Append(ssmlP);
      return this;
    }

    /// <summary>
    /// Create a new <P/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    [System.Obsolete("This method is deprecated, use .P() instead.")]
    public SsmlProsody SsmlP(string words = null)
    {
      return P(words);
    }

    /// <summary>
    /// Create a new <Phoneme/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="alphabet"> Specify the phonetic alphabet </param>
    /// <param name="ph"> Specifiy the phonetic symbols for pronunciation </param>
    public SsmlProsody Phoneme(string words = null, SsmlPhoneme.AlphabetEnum alphabet = null, string ph = null)
    {
      var newChild = new SsmlPhoneme(words, alphabet, ph);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <Phoneme/> element as a child of this element
    /// </summary>
    /// <param name="ssmlPhoneme"> A SsmlPhoneme instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlPhoneme(SsmlPhoneme ssmlPhoneme)
    {
      this.Append(ssmlPhoneme);
      return this;
    }

    /// <summary>
    /// Create a new <Phoneme/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="alphabet"> Specify the phonetic alphabet </param>
    /// <param name="ph"> Specifiy the phonetic symbols for pronunciation </param>
    [System.Obsolete("This method is deprecated, use .Phoneme() instead.")]
    public SsmlProsody SsmlPhoneme(string words = null, SsmlPhoneme.AlphabetEnum alphabet = null, string ph = null)
    {
      return Phoneme(words, alphabet, ph);
    }

    /// <summary>
    /// Create a new <Prosody/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="volume"> Specify the volume, available values: default, silent, x-soft, soft, medium, loud, x-loud,
    ///              +ndB, -ndB </param>
    /// <param name="rate"> Specify the rate, available values: x-slow, slow, medium, fast, x-fast, n% </param>
    /// <param name="pitch"> Specify the pitch, available values: default, x-low, low, medium, high, x-high, +n%, -n%
    ///             </param>
    public SsmlProsody Prosody(string words = null, string volume = null, string rate = null, string pitch = null)
    {
      var newChild = new SsmlProsody(words, volume, rate, pitch);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <Prosody/> element as a child of this element
    /// </summary>
    /// <param name="ssmlProsody"> A SsmlProsody instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody AppendSsmlProsody(SsmlProsody ssmlProsody)
    {
      this.Append(ssmlProsody);
      return this;
    }

    /// <summary>
    /// Create a new <Prosody/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="volume"> Specify the volume, available values: default, silent, x-soft, soft, medium, loud, x-loud,
    ///              +ndB, -ndB </param>
    /// <param name="rate"> Specify the rate, available values: x-slow, slow, medium, fast, x-fast, n% </param>
    /// <param name="pitch"> Specify the pitch, available values: default, x-low, low, medium, high, x-high, +n%, -n%
    ///             </param>
    [System.Obsolete("This method is deprecated, use .Prosody() instead.")]
    public SsmlProsody AppendSsmlProsody(string words = null,
                                         string volume = null,
                                         string rate = null,
                                         string pitch = null)
    {
      return Prosody(words, volume, rate, pitch);
    }

    /// <summary>
    /// Create a new <S/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    public SsmlProsody S(string words = null)
    {
      var newChild = new SsmlS(words);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <S/> element as a child of this element
    /// </summary>
    /// <param name="ssmlS"> A SsmlS instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlS(SsmlS ssmlS)
    {
      this.Append(ssmlS);
      return this;
    }

    /// <summary>
    /// Create a new <S/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    [System.Obsolete("This method is deprecated, use .S() instead.")]
    public SsmlProsody SsmlS(string words = null)
    {
      return S(words);
    }

    /// <summary>
    /// Create a new <Say-As/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to be interpreted, the body of the TwiML Element. </param>
    /// <param name="interpret-As"> Specify the type of words are spoken </param>
    /// <param name="role"> Specify the format of the date when interpret-as is set to date </param>
    public SsmlProsody SayAs(string words = null,
                             SsmlSayAs.InterpretAsEnum interpretAs = null,
                             SsmlSayAs.RoleEnum role = null)
    {
      var newChild = new SsmlSayAs(words, interpretAs, role);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <Say-As/> element as a child of this element
    /// </summary>
    /// <param name="ssmlSayAs"> A SsmlSayAs instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlSayAs(SsmlSayAs ssmlSayAs)
    {
      this.Append(ssmlSayAs);
      return this;
    }

    /// <summary>
    /// Create a new <Say-As/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to be interpreted, the body of the TwiML Element. </param>
    /// <param name="interpret-As"> Specify the type of words are spoken </param>
    /// <param name="role"> Specify the format of the date when interpret-as is set to date </param>
    [System.Obsolete("This method is deprecated, use .SayAs() instead.")]
    public SsmlProsody SsmlSayAs(string words = null,
                                 SsmlSayAs.InterpretAsEnum interpretAs = null,
                                 SsmlSayAs.RoleEnum role = null)
    {
      return SayAs(words, interpretAs, role);
    }

    /// <summary>
    /// Create a new <Sub/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to be substituted, the body of the TwiML Element. </param>
    /// <param name="alias"> Substitute a different word (or pronunciation) for selected text such as an acronym or
    ///             abbreviation </param>
    public SsmlProsody Sub(string words = null, string alias = null)
    {
      var newChild = new SsmlSub(words, alias);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <Sub/> element as a child of this element
    /// </summary>
    /// <param name="ssmlSub"> A SsmlSub instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlSub(SsmlSub ssmlSub)
    {
      this.Append(ssmlSub);
      return this;
    }

    /// <summary>
    /// Create a new <Sub/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to be substituted, the body of the TwiML Element. </param>
    /// <param name="alias"> Substitute a different word (or pronunciation) for selected text such as an acronym or
    ///             abbreviation </param>
    [System.Obsolete("This method is deprecated, use .Sub() instead.")]
    public SsmlProsody SsmlSub(string words = null, string alias = null)
    {
      return Sub(words, alias);
    }

    /// <summary>
    /// Create a new <W/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="role"> Customize the pronunciation of words by specifying the word’s part of speech or alternate
    ///            meaning </param>
    public SsmlProsody W(string words = null, string role = null)
    {
      var newChild = new SsmlW(words, role);
      this.Append(newChild);
      return this;
    }

    /// <summary>
    /// Append a <W/> element as a child of this element
    /// </summary>
    /// <param name="ssmlW"> A SsmlW instance. </param>
    [System.Obsolete("This method is deprecated, use .Append() instead.")]
    public SsmlProsody SsmlW(SsmlW ssmlW)
    {
      this.Append(ssmlW);
      return this;
    }

    /// <summary>
    /// Create a new <W/> element and append it as a child of this element.
    /// </summary>
    /// <param name="words"> Words to speak, the body of the TwiML Element. </param>
    /// <param name="role"> Customize the pronunciation of words by specifying the word’s part of speech or alternate
    ///            meaning </param>
    [System.Obsolete("This method is deprecated, use .W() instead.")]
    public SsmlProsody SsmlW(string words = null, string role = null)
    {
      return W(words, role);
    }

    /// <summary>
    /// Append a child TwiML element to this element returning this element to allow chaining.
    /// </summary>
    /// <param name="childElem"> Child TwiML element to add </param>
    public new SsmlProsody Append(TwiML childElem)
    {
      return (SsmlProsody)base.Append(childElem);
    }

    /// <summary>
    /// Add freeform key-value attributes to the generated xml
    /// </summary>
    /// <param name="key"> Option key </param>
    /// <param name="value"> Option value </param>
    public new SsmlProsody SetOption(string key, object value)
    {
      return (SsmlProsody)base.SetOption(key, value);
    }
  }

}